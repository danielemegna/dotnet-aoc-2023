namespace aoc2023.day22;

using Xunit;

public class BrickTest
{
  public class IsOccupying
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
    public void IsOccupyingMiddleCoordinateOnX()
    {
      var brick = new Brick(new(0, 2, 3), new(2, 2, 3));
      Assert.True(brick.IsOccupying(new(1, 2, 3)));
    }

    [Fact]
    public void IsOccupyingMiddleCoordinateOnY()
    {
      var brick = new Brick(new(1, 0, 1), new(1, 2, 1));
      Assert.True(brick.IsOccupying(new(1, 1, 1)));
    }

    [Fact]
    public void IsOccupyingMiddleCoordinateOnZ()
    {
      var brick = new Brick(new(1, 1, 3), new(1, 1, 9));
      Assert.True(brick.IsOccupying(new(1, 1, 7)));
    }

    [Fact]
    public void IsOccupyingMiddleCoordinateOnYWithReverseStartEndCoordinates()
    {
      var brick = new Brick(new(1, 2, 1), new(1, 0, 1));
      Assert.True(brick.IsOccupying(new(1, 1, 1)));
    }

    [Fact]
    public void NullBricksDoNotOccupyAnyCoordinate()
    {
      var brick = new NullBrick(new(1, 1, 1));
      Assert.False(brick.IsOccupying(new(1, 1, 1)));
      Assert.False(brick.IsOccupying(new(0, 1, 1)));
    }

  }

  public class GetOccupiedCoortinates()
  {

    [Fact]
    public void OfSingleCube()
    {
      var brick = new Brick(new(0, 1, 2), new(0, 1, 2));
      Assert.Equal([new(0, 1, 2)], brick.GetOccupiedCoordinates());
    }

    [Fact]
    public void OfHorizontalBricks()
    {
      Assert.Equal(
        [new(0, 1, 2), new(1, 1, 2), new(2, 1, 2)],
        new Brick(new(0, 1, 2), new(2, 1, 2)).GetOccupiedCoordinates()
      );
      Assert.Equal(
        [new(1, 3, 2), new(1, 4, 2), new(1, 5, 2), new(1, 6, 2)],
        new Brick(new(1, 3, 2), new(1, 6, 2)).GetOccupiedCoordinates()
      );
    }

    [Fact]
    public void OfVerticalBrick()
    {
      var brick = new Brick(new(1, 5, 4), new(1, 5, 2));
      Assert.Equal([new(1, 5, 2), new(1, 5, 3), new(1, 5, 4)], brick.GetOccupiedCoordinates());
    }
  }

  public class GetBelowCoordinates()
  {

    [Fact]
    public void OfSingleCube()
    {
      var brick = new Brick(new(0, 1, 2), new(0, 1, 2));
      Assert.Equal([new(0, 1, 1)], brick.GetBelowCoordinates());
    }

    [Fact]
    public void OfHorizontalBricks()
    {
      var brick = new Brick(new(0, 1, 2), new(2, 1, 2));
      Assert.Equal([new(0, 1, 1), new(1, 1, 1), new(2, 1, 1)], brick.GetBelowCoordinates());
      brick = new Brick(new(1, 3, 2), new(1, 6, 2));
      Assert.Equal([new(1, 3, 1), new(1, 4, 1), new(1, 5, 1), new(1, 6, 1)], brick.GetBelowCoordinates());
    }

    [Fact]
    public void OfVerticalBrick()
    {
      var brick = new Brick(new(1, 5, 4), new(1, 5, 2));
      Assert.Equal([new(1, 5, 1)], brick.GetBelowCoordinates());
    }
  }

  [Fact]
  public void MoveDownReturnsNewBrickWithDecreasedZValue()
  {
    var cubeBrick = new Brick(new(0, 1, 2), new(0, 1, 2));
    var horizontalBrickX = new Brick(new(0, 1, 2), new(2, 1, 2));
    var horizontalBrickY = new Brick(new(1, 3, 2), new(1, 6, 2));
    var verticalBrick = new Brick(new(1, 5, 4), new(1, 5, 2));

    Assert.Equal(new Brick(new(0, 1, 1), new(0, 1, 1)), cubeBrick.MoveDown());
    Assert.Equal(new Brick(new(0, 1, 1), new(2, 1, 1)), horizontalBrickX.MoveDown());
    Assert.Equal(new Brick(new(1, 3, 1), new(1, 6, 1)), horizontalBrickY.MoveDown());
    Assert.Equal(new Brick(new(1, 5, 3), new(1, 5, 1)), verticalBrick.MoveDown());
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
    Assert.Equal(new(7, 3, 3), invertOnX.EndCoordinate);
    var invertOnZ = new Brick(new(5, 6, 3), new(5, 6, 1));
    Assert.Equal(new(5, 6, 1), invertOnZ.StartCoordinate);
    Assert.Equal(new(5, 6, 3), invertOnZ.EndCoordinate);
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
    Assert.True(first == third);
    Assert.NotSame(first, third);

    Assert.NotEqual(second, third);
    Assert.NotEqual(second.GetHashCode(), third.GetHashCode());
    Assert.False(second == third);
    Assert.NotSame(second, third);

    Assert.Equal(first, fourth);
    Assert.Equal(first.GetHashCode(), fourth.GetHashCode());
    Assert.True(first == fourth);
    Assert.NotSame(first, fourth);
  }

}