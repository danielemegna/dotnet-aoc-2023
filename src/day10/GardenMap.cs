namespace aoc2023.day10;

using System.Collections;

public class GardenMap
{
  private readonly char[][] map;

  public Coordinate LoopStartCoordinate { get; }
  public int LoopLength { get; }
  public (Coordinate, Coordinate) LoopBoundaries { get; }

  internal GardenMap(char[][] map)
  {
    this.map = map;
    (
      this.LoopStartCoordinate,
      this.LoopLength,
      this.LoopBoundaries
    ) = LoopDetailsFromMap();
  }

  public static GardenMap From(string[] inputLines)
  {
    char[][] matrixOfChars = inputLines.Select(line => line.ToCharArray()).ToArray();
    return new GardenMap(matrixOfChars);
  }

  private Coordinate FindLoopStartCoordinate() // TODO put at the bottom or make static
  {
    var startingY = this.map
      .Select((line, lineIndex) => (line, lineIndex))
      .Where(tuple => tuple.line.Contains('S'))
      .First()
      .lineIndex;

    var startingX = Array.IndexOf(this.map[startingY], 'S');

    return new Coordinate(startingX, startingY);
  }

  private (Coordinate, int, (Coordinate, Coordinate)) LoopDetailsFromMap() // TODO put at the bottom or make static
  {
    Coordinate startCoordinate = FindLoopStartCoordinate();

    int loopLength = 0;
    var (minX, minY) = startCoordinate;
    var (maxX, maxY) = startCoordinate;
    Coordinate? previousPosition = null;
    Coordinate currentPosition = startCoordinate;

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
    } while (currentPosition != startCoordinate);

    var loopBoundaries = (new Coordinate(minX, minY), new Coordinate(maxX, maxY));
    return (startCoordinate, loopLength, loopBoundaries);
  }

  public (Coordinate, Coordinate) ConnectionsFor(Coordinate c)
  {
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
      'S' => ConnectionsForStartCoordinate(c),
      _ => throw new SystemException($"Cannot find connections for {c} = '{coordinateValue}'"),
    };
  }

  private (Coordinate, Coordinate) ConnectionsForStartCoordinate(Coordinate c)
  {
    var eastCoordinate = new Coordinate(c.X + 1, c.Y);
    var westCoordinate = new Coordinate(c.X - 1, c.Y);
    var southCoordinate = new Coordinate(c.X, c.Y + 1);
    var nordCoordinate = new Coordinate(c.X, c.Y - 1);

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
      throw new SystemException($"Cannot find connection for starting point {c}");

    return (leftConnection, rightConnection);
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
