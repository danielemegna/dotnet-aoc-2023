namespace aoc2023.day10;

using System.Collections;

public class GardenMap
{
  private readonly char[][] map;
  internal GardenMap(char[][] map) => this.map = map;

  public static GardenMap From(string[] inputLines)
  {
    char[][] matrixOfChars = inputLines.Select(line => line.ToCharArray()).ToArray();
    return new GardenMap(matrixOfChars);
  }

  public Coordinate StartingPosition()
  {
    var startingY = map
      .Select((line, lineIndex) => (line, lineIndex))
      .Where(tuple => tuple.line.Contains('S'))
      .First()
      .lineIndex;

    var startingX = Array.IndexOf(map[startingY], 'S');

    return new Coordinate(startingX, startingY);
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
      'S' => ConnectionsForStartingPoint(c),
       _ => throw new SystemException($"Cannot find connections for {c} = '{coordinateValue}'"),
    };
  }

  private (Coordinate, Coordinate) ConnectionsForStartingPoint(Coordinate c)
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
