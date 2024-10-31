namespace aoc2023.day16;

using Xunit;

public class ContraptionMapTest
{


  private readonly ContraptionMap simpleSmallMapWithSingleMirror = ContraptionMap.From([
    @"..\",
    @"...",
    @"..."
  ]);

  public class SimpleEmptyMapTest
  {

    private readonly static string[] SIMPLE_SMALL_EMPTY_MAP_ROWS = [
      "...",
      "...",
      "..."
    ];

    [Fact]
    public void NewMapShouldHaveSingleBeamAtZeroZeroWithDirectionRight()
    {
      var map = ContraptionMap.From(SIMPLE_SMALL_EMPTY_MAP_ROWS);

      var actualBeams = map.GetExistingBeams();

      Assert.Single(actualBeams);
      var beam = actualBeams.First();
      Assert.Equal(new Coordinate(X: 0, Y: 0), beam.Key);
      Assert.Equal(ContraptionMap.BeamDirection.RIGHT, beam.Value);
    }

    [Fact]
    public void GetExistingBeamsAfterMoveNextAllBeams()
    {
      var map = ContraptionMap.From(SIMPLE_SMALL_EMPTY_MAP_ROWS);

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 1, Y: 0),
        expectedDirection: ContraptionMap.BeamDirection.RIGHT,
        map: map
      );
    }

    [Fact]
    public void GetExistingBeamsAfterMoveNextAllBeamsTwice()
    {
      var map = ContraptionMap.From(SIMPLE_SMALL_EMPTY_MAP_ROWS);

      map.MoveNextAllBeams();
      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 2, Y: 0),
        expectedDirection: ContraptionMap.BeamDirection.RIGHT,
        map: map
      );
    }

    [Fact]
    public void BeamsDisappearMovingOutsideTheMapBoundariesOnEast()
    {
      var map = SimpleSmallEmptyMapAnd(
        initialBeamCoordinate: new Coordinate(X: 2, Y: 0),
        initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();
      
      var actualBeams = map.GetExistingBeams();
      Assert.Equal([], actualBeams);
    }

    [Fact]
    public void BeamsDisappearMovingOutsideTheMapBoundariesOnNorth()
    {
      var map = SimpleSmallEmptyMapAnd(
        initialBeamCoordinate: new Coordinate(X: 0, Y: 0),
        initialBeamDirection: ContraptionMap.BeamDirection.UP
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal([], actualBeams);
    }

    [Fact]
    public void BeamsDisappearMovingOutsideTheMapBoundariesOnWest()
    {
      var map = SimpleSmallEmptyMapAnd(
        initialBeamCoordinate: new Coordinate(X: 0, Y: 0),
        initialBeamDirection: ContraptionMap.BeamDirection.LEFT
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal([], actualBeams);
    }

    [Fact]
    public void MoveNextAllBeamsDoesNothingAfterAllBeamsDisappeared()
    {
      var map = ContraptionMap.From(SIMPLE_SMALL_EMPTY_MAP_ROWS);

      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal([], actualBeams);
    }

    private ContraptionMap SimpleSmallEmptyMapAnd(
      Coordinate initialBeamCoordinate,
      ContraptionMap.BeamDirection initialBeamDirection
    )
    {
      return ContraptionMap.From(
        mapRows: SIMPLE_SMALL_EMPTY_MAP_ROWS,
        initialBeamCoordinate: initialBeamCoordinate,
        initialBeamDirection: initialBeamDirection
      );
    }
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
  public void Hit_NorthWestSouthEast_MirrorFromNorthShouldMoveBeamToRight()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 1, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.DOWN
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 2),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: map
    );
  }

  [Fact]
  public void Hit_SouthWestNorthEast_MirrorFromWestShouldMoveBeamToUp()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 2, Y: 2),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 3, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.UP,
      map: map
    );
  }

  [Fact]
  public void Hit_SouthWestNorthEast_MirrorFromSouthShouldMoveBeamToRight()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 3, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.UP
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 4, Y: 0),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: map
    );
  }

  [Fact]
  public void Hit_NorthWestSouthEast_MirrorFromWestShouldMoveBeamToDown()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 4, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 5, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: map
    );
  }

  [Fact]
  public void Hit_SouthWestNorthEast_MirrorFromNorthShouldMoveBeamToLeft()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 5, Y: 4),
      initialBeamDirection: ContraptionMap.BeamDirection.DOWN
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 4, Y: 5),
      expectedDirection: ContraptionMap.BeamDirection.LEFT,
      map: map
    );
  }

  [Fact]
  public void Hit_NorthWestSouthEast_MirrorFromEastShouldMoveBeamToUp()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 4, Y: 5),
      initialBeamDirection: ContraptionMap.BeamDirection.LEFT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 3, Y: 4),
      expectedDirection: ContraptionMap.BeamDirection.UP,
      map: map
    );
  }

  [Fact]
  public void Hit_NorthWestSouthEast_MirrorFromSouthShouldMoveBeamToLeft()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 1, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.UP
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 0, Y: 0),
      expectedDirection: ContraptionMap.BeamDirection.LEFT,
      map: map
    );
  }

  [Fact]
  public void Hit_SouthWestNorthEast_MirrorFromEastShouldMoveBeamToDown()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 4, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.LEFT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 3, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: map
    );
  }

  [Fact]
  public void HitAMirrorAndDisappearMovingOutsideTheMapBoundaries()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 1, Y: 5),
      initialBeamDirection: ContraptionMap.BeamDirection.LEFT
    );

    map.MoveNextAllBeams();

    var actualBeams = map.GetExistingBeams();
    Assert.Equal([], actualBeams);
  }

  [Fact]
  public void HitTwoAdjacentMirrorsInAMoveShouldMoveTheBeamTwice()
  {
    var map = MapWithSomeMirrorsAnd(
      initialBeamCoordinate: new(X: 3, Y: 4),
      initialBeamDirection: ContraptionMap.BeamDirection.UP
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 4),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: map
    );
  }

  [Fact]
  public void HitSeveralAdjacentMirrorsShouldMoveTheBeamThroughAll()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @".\/\",
        @".\//",
        @"..\.",
        @"....",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 3, Y: 2),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: map
    );
  }

  [Fact]
  public void HitSeveralAdjacentMirrorsAndDisappearMovingOutsideTheMapBoundaries()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @".\/\",
        @".\/\",
        @"....",
        @"....",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    var actualBeams = map.GetExistingBeams();
    Assert.Equal([], actualBeams);
  }

  [Fact]
  public void MapWithAMirrorInStartingBeamCoordinateShouldMoveTheBeamOnInit()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"\..",
        @"...",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 0, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: map
    );
  }

  [Fact]
  public void BeamsShouldStepOverSplittersHittingItsPointyEndFromWest()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"...",
        @".-.",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.RIGHT,
      map: map
    );
  }

  [Fact]
  public void BeamsShouldStepOverSplittersHittingItsPointyEndFromNorth()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"...",
        @".|.",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 1, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.DOWN
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 1, Y: 2),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: map
    );
  }

  [Fact]
  public void HitASplitterPointyEndWithAdjacentMirrorShouldMoveTheBeamTwice()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"...",
        @".-/",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 2, Y: 0),
      expectedDirection: ContraptionMap.BeamDirection.UP,
      map: map
    );
  }

  [Fact]
  public void BeamShouldBeDuplicatedHittingTheFlatSideOfASplitterFromWest()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"...",
        @".|.",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    var actualBeams = map.GetExistingBeams();
    Assert.Equal(2, actualBeams.Count);
    Assert.Equal(new()
    {
      [new Coordinate(X: 1, Y: 0)] = ContraptionMap.BeamDirection.UP,
      [new Coordinate(X: 1, Y: 2)] = ContraptionMap.BeamDirection.DOWN
    }, actualBeams);
  }

  [Fact]
  public void BeamShouldBeDuplicatedHittingTheFlatSideOfASplitterFromEast()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"...",
        @".|.",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 2, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.LEFT
    );

    map.MoveNextAllBeams();

    var actualBeams = map.GetExistingBeams();
    Assert.Equal(2, actualBeams.Count);
    Assert.Equal(new()
    {
      [new Coordinate(X: 1, Y: 0)] = ContraptionMap.BeamDirection.UP,
      [new Coordinate(X: 1, Y: 2)] = ContraptionMap.BeamDirection.DOWN
    }, actualBeams);
  }

  [Fact]
  public void BeamShouldBeDuplicatedHittingTheFlatSideOfASplitterFromNorth()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"...",
        @".-.",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 1, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.DOWN
    );

    map.MoveNextAllBeams();

    var actualBeams = map.GetExistingBeams();
    Assert.Equal(2, actualBeams.Count);
    Assert.Equal(new()
    {
      [new Coordinate(X: 0, Y: 1)] = ContraptionMap.BeamDirection.LEFT,
      [new Coordinate(X: 2, Y: 1)] = ContraptionMap.BeamDirection.RIGHT
    }, actualBeams);
  }

  [Fact]
  public void BeamShouldBeDuplicatedHittingTheFlatSideOfASplitterFromSouth()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"...",
        @".-.",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 1, Y: 2),
      initialBeamDirection: ContraptionMap.BeamDirection.UP
    );

    map.MoveNextAllBeams();

    var actualBeams = map.GetExistingBeams();
    Assert.Equal(2, actualBeams.Count);
    Assert.Equal(new()
    {
      [new Coordinate(X: 0, Y: 1)] = ContraptionMap.BeamDirection.LEFT,
      [new Coordinate(X: 2, Y: 1)] = ContraptionMap.BeamDirection.RIGHT
    }, actualBeams);
  }

  [Fact]
  public void HandleAdjacentSplittersAndMirrorsAfterASingleMove()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @".-.",
        @".|.",
        @".\.",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 1),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    var actualBeams = map.GetExistingBeams();
    Assert.Equal(3, actualBeams.Count);
    Assert.Equal(new()
    {
      [new Coordinate(X: 0, Y: 0)] = ContraptionMap.BeamDirection.LEFT,
      [new Coordinate(X: 2, Y: 0)] = ContraptionMap.BeamDirection.RIGHT,
      [new Coordinate(X: 2, Y: 2)] = ContraptionMap.BeamDirection.RIGHT
    }, actualBeams);
  }

  [Fact]
  public void HitASplitterAndDisappearWhenOutOfMapBoundaries()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @".|.",
        @"...",
        @"...",
      ],
      initialBeamCoordinate: new Coordinate(X: 0, Y: 0),
      initialBeamDirection: ContraptionMap.BeamDirection.RIGHT
    );

    map.MoveNextAllBeams();

    AssertSingleBeam(
      expectedCoordinate: new Coordinate(X: 1, Y: 1),
      expectedDirection: ContraptionMap.BeamDirection.DOWN,
      map: map
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

  private ContraptionMap MapWithSomeMirrorsAnd(
    Coordinate initialBeamCoordinate,
    ContraptionMap.BeamDirection initialBeamDirection
  )
  {
    return ContraptionMap.From(
      mapRows: [
        @".\./.\",
        @"......",
        @".\./..",
        @"../\..",
        @"......",
        @"/./\./"
      ],
      initialBeamCoordinate: initialBeamCoordinate,
      initialBeamDirection: initialBeamDirection
    );
  }

}
