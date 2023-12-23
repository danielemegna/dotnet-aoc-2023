namespace aoc2023.day22;

using Xunit;

public class BricksSnapshotTest
{
  private readonly BricksSnapshot snapshot = new BricksSnapshot([
    new Brick(new(1,0,1), new(1,2,1)), new Brick(new(0,0,2), new(2,0,2)),
    new Brick(new(0,2,3), new(2,2,3)), new Brick(new(0,0,4), new(0,2,4)),
    new Brick(new(2,0,5), new(2,2,5)), new Brick(new(0,1,6), new(2,1,6)),
    new Brick(new(1,1,8), new(1,1,9)),
  ]);

  [Fact]
  public void GetBrickAtEmptyCoordinate()
  {
    Brick actual = snapshot.BrickAt(new Coordinate(0, 0, 1));
    Assert.IsType<NullBrick>(actual);
  }

  [Fact(Skip = "WIP")]
  public void GetBrickAtCoordinate()
  {
    Brick actual = snapshot.BrickAt(new Coordinate(1, 0, 1));

    Brick expected = new(new(1, 0, 1), new(1, 2, 1));
    Assert.IsType<Brick>(actual);
    Assert.Equal(expected, actual);
  }

  // TODO: test snapshots equality
  // TODO: assert two coordinates of same brick returns same object reference
  // TODO: test snapshot.BrickAt(new(x,x,0)) -> throws an exception ?

}