namespace aoc2023.day22;

public class BricksSnapshot
{
  public Brick BrickAt(Coordinate coordinate)
  {
    return new NullBrick(coordinate);
  }
}

public record class Coordinate(int X, int Y, int Z);
