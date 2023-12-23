namespace aoc2023.day22;

public class BricksSnapshot(params Brick[] bricks)
{
  public ISet<Brick> Bricks { get; } = bricks.ToHashSet();

  public Brick BrickAt(Coordinate coordinate)
  {
    return new NullBrick(coordinate);
  }
}
