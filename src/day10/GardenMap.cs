namespace aoc2023.day10;

using System.Collections;

public class GardenMap
{
  private readonly char[][] map;
  private readonly (Coordinate, Coordinate) loopStartConnections;
  private readonly ISet<Coordinate> loopCoordinates;

  public Coordinate LoopStartCoordinate { get; }
  public int LoopLength => this.loopCoordinates.Count;
  public (Coordinate, Coordinate) LoopBoundaries { get; }

  public static GardenMap From(string[] inputLines)
  {
    char[][] matrixOfChars = inputLines.Select(line => line.ToCharArray()).ToArray();
    return new GardenMap(matrixOfChars);
  }

  internal GardenMap(char[][] map)
  {
    this.map = map;
    this.LoopStartCoordinate = FindLoopStartCoordinate();
    this.loopStartConnections = FindConnectionsForLoopStart();
    this.loopCoordinates = FindLoopCoordinates();
    this.LoopBoundaries = CalculateLoopBoundaries();
  }

  public char MapValueAt(Coordinate c) =>
    this.map.ElementAtOrDefault(c.Y)?.ElementAtOrDefault(c.X) ?? 'x';

  public bool IsPartOfTheLoop(Coordinate coordinate) =>
    this.loopCoordinates.Contains(coordinate);

  public (Coordinate, Coordinate) ConnectionsFor(Coordinate c)
  {
    if (c == this.LoopStartCoordinate)
      return this.loopStartConnections;

    var coordinateValue = MapValueAt(c);
    var eastCoordinate = new Coordinate(c.X + 1, c.Y);
    var westCoordinate = new Coordinate(c.X - 1, c.Y);
    var southCoordinate = new Coordinate(c.X, c.Y + 1);
    var nordCoordinate = new Coordinate(c.X, c.Y - 1);

    return coordinateValue switch
    {
      '-' => (westCoordinate, eastCoordinate),
      'J' => (westCoordinate, nordCoordinate),
      '7' => (westCoordinate, southCoordinate),
      'L' => (nordCoordinate, eastCoordinate),
      'F' => (southCoordinate, eastCoordinate),
      '|' => (nordCoordinate, southCoordinate),
      _ => throw new SystemException($"Cannot find connections for {c} = '{coordinateValue}'"),
    };
  }

  private Coordinate FindLoopStartCoordinate()
  {
    var startingY = this.map
      .Select((line, lineIndex) => (line, lineIndex))
      .Where(tuple => tuple.line.Contains('S'))
      .First()
      .lineIndex;

    var startingX = Array.IndexOf(this.map[startingY], 'S');

    return new Coordinate(startingX, startingY);
  }

  private (Coordinate, Coordinate) FindConnectionsForLoopStart()
  {
    var eastCoordinate = new Coordinate(this.LoopStartCoordinate.X + 1, this.LoopStartCoordinate.Y);
    var westCoordinate = new Coordinate(this.LoopStartCoordinate.X - 1, this.LoopStartCoordinate.Y);
    var southCoordinate = new Coordinate(this.LoopStartCoordinate.X, this.LoopStartCoordinate.Y + 1);
    var nordCoordinate = new Coordinate(this.LoopStartCoordinate.X, this.LoopStartCoordinate.Y - 1);

    Coordinate? leftConnection = null;
    Coordinate? rightConnection = null;

    if (arr('-', '7', 'J').Contains(MapValueAt(eastCoordinate)))
      rightConnection = eastCoordinate;

    if (arr('-', 'L', 'F').Contains(MapValueAt(westCoordinate)))
      leftConnection = westCoordinate;

    if (arr('|', '7', 'F').Contains(MapValueAt(nordCoordinate)))
    {
      if (leftConnection == null) leftConnection = nordCoordinate;
      else rightConnection = nordCoordinate;
    }

    if (arr('|', 'L', 'J').Contains(MapValueAt(southCoordinate)))
    {
      if (leftConnection == null) leftConnection = southCoordinate;
      else rightConnection = southCoordinate;
    }

    if (leftConnection == null || rightConnection == null)
      throw new SystemException($"Cannot find connection for starting point {this.LoopStartCoordinate}");

    return (leftConnection, rightConnection);
  }

  private ISet<Coordinate> FindLoopCoordinates()
  {
    var (left, right) = this.loopStartConnections;
    var result = new HashSet<Coordinate>() { this.LoopStartCoordinate, left, right };

    do
    {
      var (lLeft, lRight) = this.ConnectionsFor(left);
      var (rLeft, rRight) = this.ConnectionsFor(right);
      left = result.Contains(lLeft) ? lRight : lLeft;
      right = result.Contains(rLeft) ? rRight : rLeft;
      result.Add(left);
      result.Add(right);
    } while (left != right);

    return result;
  }

  private (Coordinate, Coordinate) CalculateLoopBoundaries()
  {
    var allX = this.loopCoordinates.Select(c => c.X);
    var minX = allX.Min();
    var maxX = allX.Max();

    var allY = this.loopCoordinates.Select(c => c.Y);
    var minY = allY.Min();
    var maxY = allY.Max();

    return (new Coordinate(minX, minY), new Coordinate(maxX, maxY));
  }

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(GardenMap)) return false;
    var otherCasted = (GardenMap)other;

    if (map.Length != otherCasted.map.Length) return false;
    for (int i = 0; i < map.Length; i++)
    {
      if (!map[i].SequenceEqual(otherCasted.map[i]))
        return false;
    }

    return true;
  }

  public override int GetHashCode() =>
    StructuralComparisons.StructuralEqualityComparer.GetHashCode(map);

  private static char[] arr(params char[] value) => value;

}
