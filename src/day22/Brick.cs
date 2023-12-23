namespace aoc2023.day22;

public record Brick(Coordinate StartCoordinate, Coordinate EndCoordinate)
{
  public virtual bool IsOccupying(Coordinate coordinate)
  {
    if (StartCoordinate == coordinate || EndCoordinate == coordinate)
      return true;

    return false;
  }
}


public record NullBrick : Brick
{
  public NullBrick(Coordinate coordinate) : base(coordinate, coordinate) { }
  public override bool IsOccupying(Coordinate coordinate) => false;
}
