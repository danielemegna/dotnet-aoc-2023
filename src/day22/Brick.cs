namespace aoc2023.day22;

public record Brick
{
  public Coordinate StartCoordinate { get; }
  public Coordinate EndCoordinate { get; }

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
      return;
    }

    StartCoordinate = endCoordinate;
    EndCoordinate = startCoordinate;
  }

  public virtual bool IsOccupying(Coordinate inspectedCoordinate)
  {
    if (StartCoordinate == inspectedCoordinate || EndCoordinate == inspectedCoordinate)
      return true;

    if (StartCoordinate.X != EndCoordinate.X)
    {
      foreach (int x in RangeOf(StartCoordinate.X, EndCoordinate.X))
      {
        if (inspectedCoordinate == StartCoordinate with { X = x })
          return true;
      }
      return false;
    }

    if (StartCoordinate.Y != EndCoordinate.Y)
    {
      foreach (int y in RangeOf(StartCoordinate.Y, EndCoordinate.Y))
      {
        if (inspectedCoordinate == StartCoordinate with { Y = y })
          return true;
      }
      return false;
    }

    if (StartCoordinate.Z != EndCoordinate.Z)
    {
      foreach (int z in RangeOf(StartCoordinate.Z, EndCoordinate.Z))
      {
        if (inspectedCoordinate == StartCoordinate with { Z = z })
          return true;
      }
      return false;
    }

    return false;
  }

  private static IEnumerable<int> RangeOf(int a, int b) => Enumerable.Range(a, b - a);
}


public record NullBrick : Brick
{
  public NullBrick(Coordinate coordinate) : base(coordinate, coordinate) { }
  public override bool IsOccupying(Coordinate coordinate) => false;
}
