namespace aoc2023.day22;

public class Brick
{
  public Coordinate StartCoordinate { get; }
  public Coordinate EndCoordinate { get; }
  private readonly HashSet<Coordinate> occupiedCoordinates;

  public Brick(Coordinate startCoordinate, Coordinate endCoordinate)
  {
    if (
      startCoordinate.X <= endCoordinate.X &&
      startCoordinate.Y <= endCoordinate.Y &&
      startCoordinate.Z <= endCoordinate.Z
    )
    {
      StartCoordinate = startCoordinate;
      EndCoordinate = endCoordinate;
    }
    else
    {
      StartCoordinate = endCoordinate;
      EndCoordinate = startCoordinate;
    }

    occupiedCoordinates = GenerateOccupiedCoordinates();
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

  public virtual bool IsOccupying(Coordinate inspectedCoordinate)
  {
    return occupiedCoordinates.Contains(inspectedCoordinate);
  }

  private static IEnumerable<int> RangeOf(int a, int b) => Enumerable.Range(a, b - a + 1);

  override public bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    Brick otherBrick = (Brick)other;

    return
      StartCoordinate.Equals(otherBrick.StartCoordinate) &&
      EndCoordinate.Equals(otherBrick.EndCoordinate);
  }

  override public int GetHashCode()
  {
    return StartCoordinate.GetHashCode() * 17 + EndCoordinate.GetHashCode();
  }
}


public class NullBrick : Brick
{
  public NullBrick(Coordinate coordinate) : base(coordinate, coordinate) { }
  public override bool IsOccupying(Coordinate coordinate) => false;
}
