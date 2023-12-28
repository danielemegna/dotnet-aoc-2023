namespace aoc2023.day22;

public record Brick
{
  public Coordinate StartCoordinate { get; }
  public Coordinate EndCoordinate { get; }

  private readonly HashSet<Coordinate> occupiedCoordinates;

  public Brick(Coordinate startCoordinate, Coordinate endCoordinate)
  {
    (StartCoordinate, EndCoordinate) = Sorted(startCoordinate, endCoordinate);
    occupiedCoordinates = GenerateOccupiedCoordinates();
  }

  public virtual bool IsOccupying(Coordinate inspectedCoordinate)
  {
    return occupiedCoordinates.Contains(inspectedCoordinate);
  }

  public virtual bool Equals(Brick? other)
  {
    if (ReferenceEquals(this, other)) return true;
    if (other is null) return false;

    return
      StartCoordinate.Equals(other.StartCoordinate) &&
      EndCoordinate.Equals(other.EndCoordinate);
  }

  override public int GetHashCode()
  {
    return StartCoordinate.GetHashCode() * 2 + EndCoordinate.GetHashCode();
  }

  private HashSet<Coordinate> GenerateOccupiedCoordinates()
  {
    if (StartCoordinate == EndCoordinate)
      return [StartCoordinate];

    if (StartCoordinate.X != EndCoordinate.X)
    {
      return RangeOf(StartCoordinate.X, EndCoordinate.X)
        .Select(x => StartCoordinate with { X = x })
        .ToHashSet();
    }

    if (StartCoordinate.Y != EndCoordinate.Y)
    {
      return RangeOf(StartCoordinate.Y, EndCoordinate.Y)
        .Select(y => StartCoordinate with { Y = y })
        .ToHashSet();
    }

    if (StartCoordinate.Z != EndCoordinate.Z)
    {
      return RangeOf(StartCoordinate.Z, EndCoordinate.Z)
        .Select(z => StartCoordinate with { Z = z })
        .ToHashSet();
    }

    throw new SystemException("Something strange is happening here ...");
  }

  private static IEnumerable<int> RangeOf(int a, int b) => Enumerable.Range(a, b - a + 1);
  private static (Coordinate, Coordinate) Sorted(Coordinate a, Coordinate b)
  {
    if (a.X <= b.X && a.Y <= b.Y && a.Z <= b.Z)
      return (a, b);
    return (b, a);
  }

}

public record NullBrick : Brick
{
  public NullBrick(Coordinate coordinate) : base(coordinate, coordinate) { }
  public override bool IsOccupying(Coordinate coordinate) => false;
}
