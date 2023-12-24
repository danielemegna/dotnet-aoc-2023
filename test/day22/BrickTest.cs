namespace aoc2023.day22;

using Xunit;

public class BrickTest
{

  [Fact]
  public void IsNotOccupyingFarCoordinate()
  {
    var brick = new Brick(new(1, 5, 1), new(1, 6, 1));
    Assert.False(brick.IsOccupying(new(1, 4, 1)));
    Assert.False(brick.IsOccupying(new(1, 7, 1)));
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

  [Fact]
  public void AutomaticallySwapStartAndEndCoordinateWhenNeeded()
  {
    var normal = new Brick(new(1, 0, 1), new(1, 2, 1));
    var invertOnY = new Brick(new(1, 2, 1), new(1, 0, 1));
    Assert.Equal(new(1, 0, 1), normal.StartCoordinate);
    Assert.Equal(new(1, 0, 1), invertOnY.StartCoordinate);
    Assert.Equal(new(1, 2, 1), normal.EndCoordinate);
    Assert.Equal(new(1, 2, 1), invertOnY.EndCoordinate);

    var invertOnX = new Brick(new(7, 3, 3), new(2, 3, 3));
    Assert.Equal(new(2, 3, 3), invertOnX.StartCoordinate);
    var invertOnZ = new Brick(new(5, 6, 3), new(5, 6, 1));
    Assert.Equal(new(5, 6, 1), invertOnZ.StartCoordinate);
  }

  [Fact]
  public void EqualityAndHashCodes()
  {
    var first = new Brick(new(1, 0, 1), new(1, 2, 1));
    var second = new Brick(new(0, 2, 3), new(2, 2, 3));
    var third = new Brick(new(1, 0, 1), new(1, 2, 1));
    var fourth = new Brick(new(1, 2, 1), new(1, 0, 1));

    Assert.Equal(first, first);
    Assert.Same(first, first);

    Assert.NotEqual(first, second);
    Assert.NotEqual(first.GetHashCode(), second.GetHashCode());
    Assert.False(first == second);
    Assert.NotSame(first, second);

    Assert.Equal(first, third);
    Assert.Equal(first.GetHashCode(), third.GetHashCode());
    Assert.False(first == third);
    Assert.NotSame(first, third);

    Assert.NotEqual(second, third);
    Assert.NotEqual(second.GetHashCode(), third.GetHashCode());
    Assert.False(first == third);
    Assert.NotSame(first, third);

    Assert.Equal(first, fourth);
    Assert.Equal(first.GetHashCode(), fourth.GetHashCode());
    Assert.False(first == fourth);
    Assert.NotSame(first, fourth);
  }

}