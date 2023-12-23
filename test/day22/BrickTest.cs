namespace aoc2023.day22;

using Xunit;

public class BrickTest
{

  [Fact]
  public void IsNotOccupyingFarCoordinate()
  {
    var brick = new Brick(new(1, 0, 1), new(1, 2, 1));
    Assert.False(brick.IsOccupying(new(0, 0, 0)));
  }

  [Fact]
  public void IsOccupyingStartCoordinate()
  {
    var brick = new Brick(new(1, 0, 1), new(1, 2, 1));
    Assert.True(brick.IsOccupying(new(1, 0, 1)));
  }

  [Fact]
  public void IsOccupyingEndCoordinate()
  {
    var brick = new Brick(new(1, 0, 1), new(1, 2, 1));
    Assert.True(brick.IsOccupying(new(1, 2, 1)));
  }

  [Fact(Skip = "WIP")]
  public void IsOccupyingMiddleCoordinate()
  {
    var brick = new Brick(new(1, 0, 1), new(1, 2, 1));
    Assert.True(brick.IsOccupying(new(1, 1, 1)));
  }

  [Fact]
  public void NullBricksDoNotOccupyAnyCoordinate()
  {
    var brick = new NullBrick(new(1,1,1));
    Assert.False(brick.IsOccupying(new(1, 1, 1)));
    Assert.False(brick.IsOccupying(new(0, 1, 1)));
  }

}