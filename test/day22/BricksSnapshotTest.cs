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
    new Brick(new(1,1,8), new(1,1,10)),
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

    [Fact]
    public void GetVerticalBrickOnItsOccupiedCoordinates()
    {
      Brick first = snapshot.BrickAt(new Coordinate(1, 1, 8));
      Brick second = snapshot.BrickAt(new Coordinate(1, 1, 9));
      Brick third = snapshot.BrickAt(new Coordinate(1, 1, 10));

      Brick expected = new Brick(new(1, 1, 8), new(1, 1, 10));
      Assert.Equal(expected, first);
      Assert.Equal(first, second);
      Assert.Equal(second, third);

      Assert.NotSame(first, expected);
      Assert.Same(first, second);
      Assert.Same(first, third);
      Assert.Same(second, third);
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
        new Brick(new(1,1,8), new(1,1,10)),
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
        new Brick(new(1,1,5), new(1,1,7)),
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
        new Brick(new(1,1,5), new(1,1,7)),
      ]);
      Assert.Equal(expectedSnapshot, snapshot);
    }

    [Fact]
    public void AMoreComplexExample()
    {
      var complexSnapshot = new BricksSnapshot([
        new Brick(new(3,0,1), new(3,2,1)), new Brick(new(6,0,1), new(9,0,1)), new Brick(new(0,2,1), new(0,5,1)), new Brick(new(6,2,1), new(6,2,3)),
        new Brick(new(4,3,2), new(4,5,2)), new Brick(new(4,9,2), new(6,9,2)), new Brick(new(6,3,2), new(6,5,2)), new Brick(new(3,9,2), new(3,9,2)), new Brick(new(6,0,2), new(8,0,2)), new Brick(new(6,1,2), new(9,1,2)), new Brick(new(1,3,2), new(1,5,2)), new Brick(new(0,4,2), new(0,6,2)), new Brick(new(9,2,2), new(9,3,2)), new Brick(new(2,0,2), new(4,0,2)), new Brick(new(5,0,2), new(5,0,3)),
        new Brick(new(1,6,3), new(3,6,3)), new Brick(new(2,8,3), new(2,9,3)), new Brick(new(8,4,3), new(8,5,3)), new Brick(new(7,2,3), new(7,2,6)), new Brick(new(2,3,3), new(2,5,3)), new Brick(new(1,0,3), new(1,3,3)), new Brick(new(5,8,3), new(5,8,3)), new Brick(new(7,9,3), new(8,9,3)), new Brick(new(0,7,3), new(0,8,3)), new Brick(new(5,7,3), new(6,7,3)), new Brick(new(7,6,3), new(7,7,3)), new Brick(new(5,3,3), new(8,3,3)), new Brick(new(2,7,3), new(4,7,3)),
        new Brick(new(0,8,4), new(0,9,4)), new Brick(new(4,9,4), new(4,9,6)), new Brick(new(3,3,4), new(6,3,4)), new Brick(new(5,1,4), new(7,1,4)), new Brick(new(5,4,4), new(5,7,4)),
        new Brick(new(1,1,5), new(3,1,5)), new Brick(new(9,0,5), new(9,2,5)), new Brick(new(5,6,5), new(5,8,5)), new Brick(new(6,0,5), new(8,0,5)), new Brick(new(7,5,5), new(7,7,5)), new Brick(new(5,9,5), new(5,9,6)), new Brick(new(7,9,5), new(8,9,5)), new Brick(new(1,2,5), new(1,5,5)),
        new Brick(new(2,7,6), new(4,7,6)), new Brick(new(5,8,6), new(5,8,8)), new Brick(new(8,5,6), new(8,7,6)), new Brick(new(1,0,6), new(3,0,6)), new Brick(new(3,3,6), new(3,3,6)),
        new Brick(new(0,7,7), new(0,8,7)), new Brick(new(4,3,7), new(4,5,7)), new Brick(new(6,3,7), new(8,3,7)), new Brick(new(9,1,7), new(9,3,7)), new Brick(new(1,7,7), new(4,7,7)), new Brick(new(1,4,7), new(1,6,7)), new Brick(new(6,1,7), new(6,1,7)),
        new Brick(new(4,6,8), new(4,7,8)), new Brick(new(0,2,8), new(2,2,8)), new Brick(new(8,5,8), new(8,5,10)), new Brick(new(3,3,8), new(3,3,10)), new Brick(new(3,9,8), new(6,9,8)), new Brick(new(0,7,8), new(0,7,10)), new Brick(new(3,0,8), new(5,0,8)), new Brick(new(5,5,8), new(5,7,8)),
      ]);

      complexSnapshot.CompleteFall();

      Assert.Equal(new Brick(new(4, 9, 1), new(6, 9, 1)), complexSnapshot.BrickAt(new(4, 9, 1)));
      Assert.Equal(new Brick(new(4, 9, 2), new(4, 9, 4)), complexSnapshot.BrickAt(new(4, 9, 2)));
      Assert.Equal(new Brick(new(4, 9, 2), new(4, 9, 4)), complexSnapshot.BrickAt(new(4, 9, 4)));
      Assert.Equal(new Brick(new(4, 9, 2), new(4, 9, 4)), complexSnapshot.BrickAt(new(4, 9, 3)));
      Assert.Equal(new Brick(new(3, 9, 5), new(6, 9, 5)), complexSnapshot.BrickAt(new(3, 9, 5)));
      Assert.Equal(
        [new Brick(new(4, 9, 2), new(4, 9, 4))],
        complexSnapshot.BricksAt([new(3, 9, 4), new(4, 9, 4), new(5, 9, 4), new(6, 9, 4)])
      );
    }

  }

  public class CheckStabilityTest : BricksSnapshotTest
  {
    private readonly BricksSnapshot stableSnapshot = new BricksSnapshot([
      new Brick(new(1,0,1), new(1,2,1)),
      new Brick(new(0,0,2), new(2,0,2)), new Brick(new(0,2,2), new(2,2,2)),
      new Brick(new(0,0,3), new(0,2,3)), new Brick(new(2,0,3), new(2,2,3)),
      new Brick(new(0,1,4), new(2,1,4)),
      new Brick(new(1,1,5), new(1,1,7)),
    ]);

    [Fact]
    public void RemoveNotLoadBearingBrick()
    {
      Assert.True(stableSnapshot.IsStableRemovingBrick(new Brick(new(0, 0, 2), new(2, 0, 2))));
      Assert.True(stableSnapshot.IsStableRemovingBrick(new Brick(new(0, 2, 2), new(2, 2, 2))));
      Assert.True(stableSnapshot.IsStableRemovingBrick(new Brick(new(0, 0, 3), new(0, 2, 3))));
      Assert.True(stableSnapshot.IsStableRemovingBrick(new Brick(new(2, 0, 3), new(2, 2, 3))));
      Assert.True(stableSnapshot.IsStableRemovingBrick(new Brick(new(1, 1, 5), new(1, 1, 7))));
    }

    [Fact]
    public void RemoveLoadBearingBrick()
    {
      Assert.False(stableSnapshot.IsStableRemovingBrick(new Brick(new(1, 0, 1), new(1, 2, 1))));
      Assert.False(stableSnapshot.IsStableRemovingBrick(new Brick(new(0, 1, 4), new(2, 1, 4))));
    }

    [Fact]
    public void CheckStabilityShouldNotAlterTheSnapshot()
    {
      Assert.Equal(new Brick(new(0, 2, 2), new(2, 2, 2)), stableSnapshot.BrickAt(new(0, 2, 2)));
      stableSnapshot.IsStableRemovingBrick(new Brick(new(0, 2, 2), new(2, 2, 2)));
      Assert.Equal(new Brick(new(0, 2, 2), new(2, 2, 2)), stableSnapshot.BrickAt(new(0, 2, 2)));
    }

    [Fact]
    public void CountSafeToDisintegrateBricks()
    {
      Assert.Equal(5, stableSnapshot.CountSafeToDisintegrateBricks());
    }
  }

  public class CountFallingBricksOnRemoveTest : BricksSnapshotTest
  {
    private readonly BricksSnapshot stableSnapshot = new BricksSnapshot([
      new Brick(new(1,0,1), new(1,2,1)),
      new Brick(new(0,0,2), new(2,0,2)), new Brick(new(0,2,2), new(2,2,2)),
      new Brick(new(0,0,3), new(0,2,3)), new Brick(new(2,0,3), new(2,2,3)),
      new Brick(new(0,1,4), new(2,1,4)),
      new Brick(new(1,1,5), new(1,1,7)),
    ]);

    [Fact]
    public void RemoveNotLoadBearingBrick()
    {
      Assert.Equal(0, stableSnapshot.CountFallingBricksRemovingBrick(new Brick(new(0, 0, 2), new(2, 0, 2))));
      Assert.Equal(0, stableSnapshot.CountFallingBricksRemovingBrick(new Brick(new(0, 2, 2), new(2, 2, 2))));
      Assert.Equal(0, stableSnapshot.CountFallingBricksRemovingBrick(new Brick(new(0, 0, 3), new(0, 2, 3))));
      Assert.Equal(0, stableSnapshot.CountFallingBricksRemovingBrick(new Brick(new(2, 0, 3), new(2, 2, 3))));
      Assert.Equal(0, stableSnapshot.CountFallingBricksRemovingBrick(new Brick(new(1, 1, 5), new(1, 1, 7))));
    }

    [Fact]
    public void RemoveBrickWithOneFallingBrickAbove()
    {
      Assert.Equal(1, stableSnapshot.CountFallingBricksRemovingBrick(new Brick(new(0, 1, 4), new(2, 1, 4))));
    }

    [Fact]
    public void RecursiveFallingShouldBeIncluded()
    {
      Assert.Equal(6, stableSnapshot.CountFallingBricksRemovingBrick(new Brick(new(1, 0, 1), new(1, 2, 1))));
    }

    [Fact]
    public void CountFallingBricksOnDisintegrates()
    {
      Assert.Equal(6 + 1, stableSnapshot.CountFallingBricksOnDisintegrates());
    }
  }

}
