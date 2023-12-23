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

  [Fact]
  public void IsOccupyingMiddleCoordinateOnY()
  {
    var brick = new Brick(new(1, 0, 1), new(1, 2, 1));
    Assert.True(brick.IsOccupying(new(1, 1, 1)));
  }

  [Fact]
  public void IsOccupyingMiddleCoordinateOnYWithReverseStartEndCoordinates()
  {
    var brick = new Brick(new(1, 2, 1), new(1, 0, 1));
    Assert.True(brick.IsOccupying(new(1, 1, 1)));
  }

  [Fact]
  public void IsOccupyingMiddleCoordinateOnX()
  {
    var brick = new Brick(new(0, 2, 3), new(2, 2, 3));
    Assert.True(brick.IsOccupying(new(1, 2, 3)));
  }

  [Fact]
  public void IsOccupyingMiddleCoordinateOnZ()
  {
    var brick = new Brick(new(1, 1, 3), new(1, 1, 9));
    Assert.True(brick.IsOccupying(new(1, 1, 7)));
  }

  [Fact]
  public void NullBricksDoNotOccupyAnyCoordinate()
  {
    var brick = new NullBrick(new(1, 1, 1));
    Assert.False(brick.IsOccupying(new(1, 1, 1)));
    Assert.False(brick.IsOccupying(new(0, 1, 1)));
  }

}