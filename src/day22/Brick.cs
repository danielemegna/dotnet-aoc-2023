namespace aoc2023.day22;

public record Brick(Coordinate StartCoordinate, Coordinate EndCoordinate)
{

  public virtual bool IsOccupying(Coordinate inspectedCoordinate)
  {
    if (StartCoordinate == inspectedCoordinate || EndCoordinate == inspectedCoordinate)
      return true;

    if (StartCoordinate.X != EndCoordinate.X)
    {
      foreach (int x in GetRange(StartCoordinate.X, EndCoordinate.X))
      {
        if (inspectedCoordinate == StartCoordinate with { X = x })
          return true;
      }
      return false;
    }

    if (StartCoordinate.Y != EndCoordinate.Y)
    {
      foreach (int y in GetRange(StartCoordinate.Y, EndCoordinate.Y))
      {
        if (inspectedCoordinate == StartCoordinate with { Y = y })
          return true;
      }
      return false;
    }

    if (StartCoordinate.Z != EndCoordinate.Z)
    {
      foreach (int z in GetRange(StartCoordinate.Z, EndCoordinate.Z))
      {
        if (inspectedCoordinate == StartCoordinate with { Z = z })
          return true;
      }
      return false;
    }

    return false;
  }

  private static IEnumerable<int> GetRange(int a, int b)
  {
    if (a < b)
      return Enumerable.Range(a, b - a);

    return Enumerable.Range(b, a - b);
  }
}


public record NullBrick : Brick
{
  public NullBrick(Coordinate coordinate) : base(coordinate, coordinate) { }
  public override bool IsOccupying(Coordinate coordinate) => false;
}
