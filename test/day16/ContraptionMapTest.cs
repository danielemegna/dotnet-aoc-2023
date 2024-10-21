namespace aoc2023.day16;

using Xunit;

public class ContraptionMapTest
{
  private readonly ContraptionMap simpleSmallEmptyMap = ContraptionMap.From([
    "...",
    "...",
    "..."
  ]);

  private readonly ContraptionMap simpleSmallMapWithSingleMirror = ContraptionMap.From([
    @"..\",
    @"...",
    @"..."
  ]);

  [Fact]
  public void GetExistingBeamsOnNewSimpleSmallMap()
  {
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 0, Y: 0)] = ContraptionMap.BeamDirection.RIGHT
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

  [Fact]
  public void GetExistingBeamsAfterMoveNextAllBeamsOnNewSimpleSmallMap()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 1, Y: 0)] = ContraptionMap.BeamDirection.RIGHT
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

  [Fact]
  public void GetExistingBeamsAfterMoveNextAllBeamsTwiceOnNewSimpleSmallMap()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 2, Y: 0)] = ContraptionMap.BeamDirection.RIGHT
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

  [Fact]
  public void BeamsDisappearMovingOutsideTheMapBoundariesOnEast()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    Assert.Equal([], actualBeams);
  }

  [Fact]
  public void MoveNextAllBeamsDoesNothingAfterAllBeamsDisappeared()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    Assert.Equal([], actualBeams);
  }

  [Fact]
  public void BeamsShouldStepOverAndChangeDirectionHittingMirror()
  {
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    var actualBeams = simpleSmallMapWithSingleMirror.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 2, Y: 1)] = ContraptionMap.BeamDirection.DOWN
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

  [Fact]
  public void MoveBeamInDownDirection()
  {
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    var actualBeams = simpleSmallMapWithSingleMirror.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 2, Y: 2)] = ContraptionMap.BeamDirection.DOWN
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

  [Fact]
  public void BeamsDisappearMovingOutsideTheMapBoundariesOnSouth()
  {
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    var actualBeams = simpleSmallMapWithSingleMirror.GetExistingBeams();

    Assert.Equal([], actualBeams);
  }

}
