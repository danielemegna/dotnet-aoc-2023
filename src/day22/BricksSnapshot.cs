namespace aoc2023.day22;

public class BricksSnapshot
{
  public ISet<Brick> Bricks { get; }

  public BricksSnapshot(params Brick[] bricks)
  {
    Bricks = bricks.ToHashSet();
  }

  public Brick BrickAt(Coordinate coordinate)
  {
    return Bricks.FirstOrDefault(
      b => b.IsOccupying(coordinate),
      new NullBrick(coordinate)
    );
  }
}
