namespace aoc2023.day10;

using System.Collections;

public class GardenMap
{
  private readonly char[][] map;

  internal GardenMap(char[][] map)
  {
    this.map = map;
  }

  public (Coordinate, Coordinate) ConnectionsFor(Coordinate c)
  {
    throw new NotImplementedException();
  }

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(GardenMap)) return false;
    var otherCasted = (GardenMap)other;

    if(map.Length != otherCasted.map.Length) return false;

    for (int i = 0; i < map.Length; i++)
    {
      if (!map[i].SequenceEqual(otherCasted.map[i]))
        return false;
    }

    return true;
  }

  public override int GetHashCode() =>
    StructuralComparisons.StructuralEqualityComparer.GetHashCode(map);
}
