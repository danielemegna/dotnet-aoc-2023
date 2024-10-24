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

  private readonly ContraptionMap mapWithSomeMirrors = ContraptionMap.From([
    @".\./.\",
    @"......",
    @".\./..",
    @"../\..",
    @"......",
    @"/./\./"
  ]);

  [Fact]
  public void NewMapShouldHaveSingleBeamAtZeroZeroWithDirectionRight()
  {
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    Assert.Single(actualBeams);
    var beam = actualBeams.First();
    Assert.Equal(new Coordinate(X: 0, Y: 0), beam.Key);
    Assert.Equal(ContraptionMap.BeamDirection.RIGHT, beam.Value);
  }

  [Fact]
  public void GetExistingBeamsAfterMoveNextAllBeamsOnNewSimpleSmallMap()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 1, Y: 0),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: simpleSmallEmptyMap
    );
  }

  [Fact]
  public void GetExistingBeamsAfterMoveNextAllBeamsTwiceOnNewSimpleSmallMap()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 0),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: simpleSmallEmptyMap
    );
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
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: simpleSmallMapWithSingleMirror
    );
  }

  [Fact]
  public void MoveBeamInDownDirection()
  {
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    simpleSmallMapWithSingleMirror.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 2),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: simpleSmallMapWithSingleMirror
    );
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

  [Fact]
  public void Hit_NorthWestSouthEst_MirrorFromNorthShouldMoveBeamToRight()
  {
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 2),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: mapWithSomeMirrors
    );
  }

  [Fact]
  public void Hit_SouthWestNorthEst_MirrorFromWestShouldMoveBeamToUp()
  {
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 3, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.UP,
      map: mapWithSomeMirrors
    );
  }

  [Fact]
  public void Hit_SouthWestNorthEst_MirrorFromSouthShouldMoveBeamToRight()
  {
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 4, Y: 0),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: mapWithSomeMirrors
    );
  }

  [Fact]
  public void Hit_NorthWestSouthEst_MirrorFromWestShouldMoveBeamToDown()
  {
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 5, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: mapWithSomeMirrors
    );
  }

  [Fact]
  public void Hit_SouthWestNorthEst_MirrorFromNorthShouldMoveBeamToLeft()
  {
    // this should become an easy test setup
    // without move next operations needed
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    mapWithSomeMirrors.MoveNextAllBeams();
    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 4, Y: 5),
      expectedDirection: ContraptionMap.BeamDirection.LEFT,
      map: mapWithSomeMirrors
    );
  }

  private static void AssertSingleBeam(
    Coordinate expectedCoordinate,
    ContraptionMap.BeamDirection expectedDirection,
    ContraptionMap map
  )
  {
    var actualBeams = map.GetExistingBeams();
    Assert.Single(actualBeams);
    var beam = actualBeams.First();
    Assert.Equal(expectedCoordinate, beam.Key);
    Assert.Equal(expectedDirection, beam.Value);
  }
}
