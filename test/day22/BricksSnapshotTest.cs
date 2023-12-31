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

  public class BricksAtTest : BricksSnapshotTest
  {

    [Fact]
    public void GetBricksAtEmptyCoordinate()
    {
      var actual = snapshot.BricksAt([new(0, 0, 1), new(12, 24, 12)]);
      Assert.Empty(actual);
    }

    [Fact]
    public void GetBricksGettingDifferentBricks()
    {
      var actual = snapshot.BricksAt([new(0, 1, 4), new(2, 1, 5)]);
      Assert.Equal(2, actual.Count);
      Assert.Contains(new Brick(new(0, 0, 4), new(0, 2, 4)), actual);
      Assert.Contains(new Brick(new(2, 0, 5), new(2, 2, 5)), actual);
    }

    [Fact]
    public void GetSameBrickWithDifferentCoordinates()
    {
      var actual = snapshot.BricksAt([new(0, 0, 4), new(0, 1, 4), new(0, 2, 4)]);
      Assert.Single(actual);
      Assert.Equal(new Brick(new(0, 0, 4), new(0, 2, 4)), actual.First());
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
      var singleBrick = new Brick(new(1, 0, 1), new(1, 2, 1));
      var simpleSnapshot = new BricksSnapshot(singleBrick);

      simpleSnapshot.CompleteFall();

      Assert.Equal(singleBrick, simpleSnapshot.BrickAt(new(1, 0, 1)));
      Assert.Equal(new BricksSnapshot(singleBrick), simpleSnapshot);
    }

    [Fact]
    public void SingleFallingBrick()
    {
      var simpleSnapshot = new BricksSnapshot([
        new Brick(new(0,0,2), new(2,0,2))
      ]);

      simpleSnapshot.CompleteFall();

      var fallenBrick = new Brick(new(0, 0, 1), new(2, 0, 1));
      Assert.Equal(fallenBrick, simpleSnapshot.BrickAt(new(0, 0, 1)));
      Assert.Equal(new BricksSnapshot(fallenBrick), simpleSnapshot);
    }

    [Fact]
    public void SingleFallingBrickFromFar()
    {
      var simpleSnapshot = new BricksSnapshot([
        new Brick(new(1,2,5), new(1,4,5))
      ]);

      simpleSnapshot.CompleteFall();

      var fallenBrick = new Brick(new(1, 2, 1), new(1, 4, 1));
      Assert.Equal(fallenBrick, simpleSnapshot.BrickAt(new(1, 2, 1)));
    }

    [Fact]
    public void FallingBrickHitAnother()
    {
      var twoBricksSnapshot = new BricksSnapshot([
        new Brick(new(0,0,3), new(0,2,3)),
        new Brick(new(0,0,1), new(0,2,1))
      ]);

      twoBricksSnapshot.CompleteFall();

      var expectedSnapshot = new BricksSnapshot([
        new Brick(new(0,0,2), new(0,2,2)),
        new Brick(new(0,0,1), new(0,2,1))
      ]);
      Assert.Equal(expectedSnapshot, twoBricksSnapshot);
    }

    [Fact]
    public void MultipleFallingBricks()
    {
      var twoBricksSnapshot = new BricksSnapshot([
        new Brick(new(0,0,5), new(0,2,5)),
        new Brick(new(2,0,5), new(2,2,5)),
      ]);

      twoBricksSnapshot.CompleteFall();

      var expectedSnapshot = new BricksSnapshot([
        new Brick(new(0,0,1), new(0,2,1)),
        new Brick(new(2,0,1), new(2,2,1)),
      ]);
      Assert.Equal(expectedSnapshot, twoBricksSnapshot);
    }

    [Fact]
    public void BricksDoNotFallOnPartialHitAtTheEnd()
    {
      var twoBricksSnapshot = new BricksSnapshot([
        new Brick(new(2,0,1), new(2,2,1)),
        new Brick(new(0,2,2), new(2,2,2)),
      ]);

      twoBricksSnapshot.CompleteFall();

      var expectedSnapshot = new BricksSnapshot([
        new Brick(new(2,0,1), new(2,2,1)),
        new Brick(new(0,2,2), new(2,2,2)),
      ]);
      Assert.Equal(expectedSnapshot, twoBricksSnapshot);
    }

    [Fact]
    public void BricksDoNotFallOnPartialHitAtMiddle()
    {
      var twoBricksSnapshot = new BricksSnapshot([
        new Brick(new(1,0,1), new(1,2,1)),
        new Brick(new(0,1,2), new(2,1,2)),
      ]);

      twoBricksSnapshot.CompleteFall();

      var expectedSnapshot = new BricksSnapshot([
        new Brick(new(1,0,1), new(1,2,1)),
        new Brick(new(0,1,2), new(2,1,2)),
      ]);
      Assert.Equal(expectedSnapshot, twoBricksSnapshot);
    }

    [Fact]
    public void MultipleCloseFallingBricks()
    {
      var twoBricksSnapshot = new BricksSnapshot([
        new Brick(new(0,0,5), new(0,2,5)),
        new Brick(new(0,0,4), new(0,2,4)),
      ]);

      twoBricksSnapshot.CompleteFall();

      var expectedSnapshot = new BricksSnapshot([
        new Brick(new(0,0,2), new(0,2,2)),
        new Brick(new(0,0,1), new(0,2,1)),
      ]);
      Assert.Equal(expectedSnapshot, twoBricksSnapshot);
    }

    [Fact]
    public void VerticalFallingBrick()
    {
      var singleBrickSnapshot = new BricksSnapshot([
        new Brick(new(0,0,7), new(0,0,9))
      ]);

      singleBrickSnapshot.CompleteFall();

      var expectedSnapshot = new BricksSnapshot([
        new Brick(new(0,0,1), new(0,0,3))
      ]);
      Assert.Equal(expectedSnapshot, singleBrickSnapshot);
    }

    [Fact]
    public void CompleteFallOfProvidedExample()
    {
      snapshot.CompleteFall();

      var expectedSnapshot = new BricksSnapshot([
        new Brick(new(1,0,1), new(1,2,1)),
        new Brick(new(0,0,2), new(2,0,2)), new Brick(new(0,2,2), new(2,2,2)),
        new Brick(new(0,0,3), new(0,2,3)), new Brick(new(2,0,3), new(2,2,3)),
        new Brick(new(0,1,4), new(2,1,4)),
        new Brick(new(1,1,5), new(1,1,6)),
      ]);
      Assert.Equal(expectedSnapshot, snapshot);
    }

  }

  public class CheckStabilityTest : BricksSnapshotTest
  {
    private readonly BricksSnapshot stableSnapshot = new BricksSnapshot([
      new Brick(new(1,0,1), new(1,2,1)),
      new Brick(new(0,0,2), new(2,0,2)), new Brick(new(0,2,2), new(2,2,2)),
      new Brick(new(0,0,3), new(0,2,3)), new Brick(new(2,0,3), new(2,2,3)),
      new Brick(new(0,1,4), new(2,1,4)),
      new Brick(new(1,1,5), new(1,1,6)),
    ]);

    [Fact]
    public void RemoveNotLoadBearingBrick()
    {
      Assert.True(stableSnapshot.CheckStabilityRemovingBrick(new Brick(new(0, 0, 2), new(2, 0, 2))));
      Assert.True(stableSnapshot.CheckStabilityRemovingBrick(new Brick(new(0, 2, 2), new(2, 2, 2))));
      Assert.True(stableSnapshot.CheckStabilityRemovingBrick(new Brick(new(0, 0, 3), new(0, 2, 3))));
      Assert.True(stableSnapshot.CheckStabilityRemovingBrick(new Brick(new(2, 0, 3), new(2, 2, 3))));
      Assert.True(stableSnapshot.CheckStabilityRemovingBrick(new Brick(new(1, 1, 5), new(1, 1, 6))));
    }

    [Fact]
    public void RemoveLoadBearingBrick()
    {
      Assert.False(stableSnapshot.CheckStabilityRemovingBrick(new Brick(new(1, 0, 1), new(1, 2, 1))));
      Assert.False(stableSnapshot.CheckStabilityRemovingBrick(new Brick(new(0, 1, 4), new(2, 1, 4))));
    }

    [Fact]
    public void CountLoadBearingBricks()
    {
      Assert.Equal(5, stableSnapshot.CountLoadBearingBricks());
    }
  }

}