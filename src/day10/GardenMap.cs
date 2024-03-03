namespace aoc2023.day10;

using System.Collections;

public class GardenMap
{
  private readonly char[][] map;

  public Coordinate LoopStartCoordinate { get; }
  public int LoopLength { get; }
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
    (this.LoopLength, this.LoopBoundaries) = LoopLengthAndBoundaries();
  }

  public (Coordinate, Coordinate) ConnectionsFor(Coordinate c)
  {
    if(c == this.LoopStartCoordinate)
      return ConnectionsForLoopStart();

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

  private (Coordinate, Coordinate) ConnectionsForLoopStart()
  {
    var eastCoordinate = new Coordinate(this.LoopStartCoordinate.X + 1, this.LoopStartCoordinate.Y);
    var westCoordinate = new Coordinate(this.LoopStartCoordinate.X - 1, this.LoopStartCoordinate.Y);
    var southCoordinate = new Coordinate(this.LoopStartCoordinate.X, this.LoopStartCoordinate.Y + 1);
    var nordCoordinate = new Coordinate(this.LoopStartCoordinate.X, this.LoopStartCoordinate.Y - 1);

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
      throw new SystemException($"Cannot find connection for starting point {this.LoopStartCoordinate}");

    return (leftConnection, rightConnection);
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

  private (int, (Coordinate, Coordinate)) LoopLengthAndBoundaries()
  {
    int loopLength = 0;
    var (minX, minY) = this.LoopStartCoordinate;
    var (maxX, maxY) = this.LoopStartCoordinate;

    Coordinate? previousPosition = null;
    Coordinate currentPosition = this.LoopStartCoordinate;
    do
    {
      var (left, right) = this.ConnectionsFor(currentPosition);
      var newPosition = left == previousPosition ? right : left;
      previousPosition = currentPosition;
      currentPosition = newPosition;

      if (currentPosition.X < minX) minX = currentPosition.X;
      if (currentPosition.X > maxX) maxX = currentPosition.X;
      if (currentPosition.Y < minY) minY = currentPosition.Y;
      if (currentPosition.Y > maxY) maxY = currentPosition.Y;

      loopLength++;
    } while (currentPosition != this.LoopStartCoordinate);

    var loopBoundaries = (new Coordinate(minX, minY), new Coordinate(maxX, maxY));
    return (loopLength, loopBoundaries);
  }

  private char MapValueAt(Coordinate c) =>
    map.ElementAtOrDefault(c.Y)?.ElementAtOrDefault(c.X) ?? 'x';

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
