namespace aoc2023.day22;

using Xunit;

public class BricksSnapshotTest
{
  private readonly BricksSnapshot snapshot = new BricksSnapshot([
    new Brick(new(1,0,1), new(1,2,1)),
    new Brick(new(0,0,2), new(2,0,2)),
    new Brick(new(0,2,3), new(2,2,3)),
    new Brick(new(0,0,4), new(0,2,4)),
    new Brick(new(2,0,5), new(2,2,5)),
    new Brick(new(0,1,6), new(2,1,6)),
    new Brick(new(1,1,8), new(1,1,9)),
  ]);

  public class BrickAtTest : BricksSnapshotTest
  {

    [Fact]
    public void GetBrickAtEmptyCoordinate()
    {
      Brick actual = snapshot.BrickAt(new Coordinate(0, 0, 1));
      Assert.IsType<NullBrick>(actual);
      actual = snapshot.BrickAt(new Coordinate(0, 0, 0));
      Assert.IsType<NullBrick>(actual);
    }

    [Fact]
    public void GetBrickAtBrickStartCoordinate()
    {
      Brick actual = snapshot.BrickAt(new Coordinate(1, 0, 1));
      Brick expected = new(new(1, 0, 1), new(1, 2, 1));
      Assert.IsType<Brick>(actual);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetBrickAtBrickMiddleCoordinate()
    {
      Brick actual = snapshot.BrickAt(new Coordinate(2, 1, 5));
      Brick expected = new(new(2, 0, 5), new(2, 2, 5));
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TwoCoordinatesOccupiedBySameBrickReturnSameObjectReference()
    {
      Brick first = snapshot.BrickAt(new Coordinate(0, 0, 4));
      Brick second = snapshot.BrickAt(new Coordinate(0, 1, 4));
      Assert.True(first == second);
      Assert.Same(first, second);
    }

  }

  public class Equality : BricksSnapshotTest
  {

    [Fact]
    public void EqualityForCloneSnapshot()
    {
      BricksSnapshot clone = new BricksSnapshot([
        new Brick(new(1,0,1), new(1,2,1)),
        new Brick(new(0,0,2), new(2,0,2)),
        new Brick(new(0,2,3), new(2,2,3)),
        new Brick(new(0,0,4), new(0,2,4)),
        new Brick(new(2,0,5), new(2,2,5)),
        new Brick(new(0,1,6), new(2,1,6)),
        new Brick(new(1,1,8), new(1,1,9)),
    ]);

      Assert.NotSame(snapshot, clone);
      Assert.Equal(snapshot, clone);
      Assert.Equal(snapshot.GetHashCode(), clone.GetHashCode());
      Assert.False(snapshot == clone);
    }

    [Fact]
    public void EqualityForDifferentSnapshot()
    {
      BricksSnapshot another = new BricksSnapshot([
        new Brick(new(1,0,1), new(1,2,1)),
        new Brick(new(0,0,2), new(2,0,2)), new Brick(new(0,2,2), new(2,2,2)),
        new Brick(new(0,0,3), new(0,2,3)), new Brick(new(2,0,3), new(2,2,3)),
        new Brick(new(0,1,4), new(2,1,4)),
        new Brick(new(1,1,5), new(1,1,6)),
    ]);

      Assert.NotSame(snapshot, another);
      Assert.NotEqual(snapshot, another);
      Assert.NotEqual(snapshot.GetHashCode(), another.GetHashCode());
      Assert.False(snapshot == another);
    }

  }

  public class CompleteFallTest : BricksSnapshotTest
  {
    [Fact]
    public void SingleNotFallingBrick()
    {
      var singleBrick = new Brick(new(1,0,1), new(1,2,1));
      var simpleSnapshot = new BricksSnapshot([singleBrick]);

      simpleSnapshot.CompleteFall();

      Assert.Equal(singleBrick, simpleSnapshot.BrickAt(new(1,0,1)));
      Assert.Equal([singleBrick], simpleSnapshot.Bricks);
    }

    [Fact]
    public void SingleFallingBrick()
    {
      var simpleSnapshot = new BricksSnapshot([
        new Brick(new(0,0,2), new(2,0,2))
      ]);

      simpleSnapshot.CompleteFall();

      var expectedBrick = new Brick(new(0,0,1), new(2,0,1));
      Assert.Equal(expectedBrick, simpleSnapshot.BrickAt(new(0,0,1)));
      Assert.Equal([expectedBrick], simpleSnapshot.Bricks);
    }

    [Fact]
    public void SingleFallingBrickFromFar()
    {
      var simpleSnapshot = new BricksSnapshot([
        new Brick(new(1,2,5), new(1,4,5))
      ]);

      simpleSnapshot.CompleteFall();

      var expectedBrick = new Brick(new(1,2,1), new(1,4,1));
      Assert.Equal(expectedBrick, simpleSnapshot.BrickAt(new(1,2,1)));
    }

    [Fact]
    public void FallingBrickHitAnother()
    {
      var simpleSnapshot = new BricksSnapshot([
        new Brick(new(0,0,3), new(0,2,3)),
        new Brick(new(0,0,1), new(0,2,1))
      ]);

      simpleSnapshot.CompleteFall();

      var expectedBrick = new Brick(new(0,0,2), new(0,2,2));
      Assert.Equal(expectedBrick, simpleSnapshot.BrickAt(new(0,0,2)));
    }
  }

}