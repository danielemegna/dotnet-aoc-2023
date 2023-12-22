namespace aoc2023.day22;

public record Brick(Coordinate StartCoordinate, Coordinate EndCoordinate);

public record NullBrick : Brick
{
  public NullBrick(Coordinate coordinate) : base(coordinate, coordinate) { }
}
