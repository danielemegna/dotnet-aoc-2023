namespace aoc2023.day10;

using System.Collections;

public class GardenMap
{
  private readonly char[][] map;
  private readonly Coordinate loopStartCoordinate;
  private readonly (Coordinate, Coordinate) loopStartConnections;
  private readonly ISet<Coordinate> loopCoordinates;

  public int LoopLength => this.loopCoordinates.Count;
  public (Coordinate, Coordinate) LoopBoundaries
  {
    get
    {
      var allX = this.loopCoordinates.Select(c => c.X);
      var minX = allX.Min();
      var maxX = allX.Max();

      var allY = this.loopCoordinates.Select(c => c.Y);
      var minY = allY.Min();
      var maxY = allY.Max();

      return (new Coordinate(minX, minY), new Coordinate(maxX, maxY));
    }
  }

  public static GardenMap From(string[] inputLines)
  {
    char[][] matrixOfChars = inputLines.Select(line => line.ToCharArray()).ToArray();
    return new GardenMap(matrixOfChars);
  }

  internal GardenMap(char[][] map)
  {
    this.map = map;
    this.loopStartCoordinate = FindLoopStartCoordinate();
    this.loopStartConnections = FindConnectionsForLoopStart();
    this.loopCoordinates = FindLoopCoordinates();
  }

  public char MapValueAt(Coordinate c) =>
    map.ElementAtOrDefault(c.Y)?.ElementAtOrDefault(c.X) ?? 'x';

  public (Coordinate, Coordinate) ConnectionsFor(Coordinate c)
  {
    if (c == this.loopStartCoordinate)
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

  public bool IsPartOfTheLoop(Coordinate coordinate)
  {
    return this.loopCoordinates.Contains(coordinate);
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
    var eastCoordinate = new Coordinate(this.loopStartCoordinate.X + 1, this.loopStartCoordinate.Y);
    var westCoordinate = new Coordinate(this.loopStartCoordinate.X - 1, this.loopStartCoordinate.Y);
    var southCoordinate = new Coordinate(this.loopStartCoordinate.X, this.loopStartCoordinate.Y + 1);
    var nordCoordinate = new Coordinate(this.loopStartCoordinate.X, this.loopStartCoordinate.Y - 1);

    Coordinate? leftConnection = null;
    Coordinate? rightConnection = null;

    if (arr(['-', '7', 'J']).Contains(MapValueAt(eastCoordinate)))
      rightConnection = eastCoordinate;

    if (arr(['-', 'L', 'F']).Contains(MapValueAt(westCoordinate)))
      leftConnection = westCoordinate;

    if (arr(['|', '7', 'F']).Contains(MapValueAt(nordCoordinate)))
    {
      if (leftConnection == null) leftConnection = nordCoordinate;
      else rightConnection = nordCoordinate;
    }

    if (arr(['|', 'L', 'J']).Contains(MapValueAt(southCoordinate)))
    {
      if (leftConnection == null) leftConnection = southCoordinate;
      else rightConnection = southCoordinate;
    }

    if (leftConnection == null || rightConnection == null)
      throw new SystemException($"Cannot find connection for starting point {this.loopStartCoordinate}");

    return (leftConnection, rightConnection);
  }

  private ISet<Coordinate> FindLoopCoordinates()
  {
    var result = new HashSet<Coordinate>();
    Coordinate? previousPosition = null;
    Coordinate currentPosition = this.loopStartCoordinate;
    do
    {
      result.Add(currentPosition);

      var (left, right) = this.ConnectionsFor(currentPosition);
      var newPosition = left == previousPosition ? right : left;
      previousPosition = currentPosition;
      currentPosition = newPosition;
    } while (currentPosition != this.loopStartCoordinate);

    return result;
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

  private static char[] arr(char[] value) => value;

}
