namespace aoc2023.day16;

using Xunit;

public class ContraptionMapTest
{

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
      Assert.Equal(BeamDirection.RIGHT, beam.Value);
    }

    [Fact]
    public void GetExistingBeamsAfterMoveNextAllBeams()
    {
      var map = ContraptionMap.From(SIMPLE_SMALL_EMPTY_MAP_ROWS);

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 1, Y: 0),
        expectedDirection: BeamDirection.RIGHT,
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
        expectedDirection: BeamDirection.RIGHT,
        map: map
      );
    }

    [Fact]
    public void BeamsDisappearMovingOutsideTheMapBoundariesOnEast()
    {
      var map = SimpleSmallEmptyMapAnd(
        initialBeamCoordinate: new Coordinate(X: 2, Y: 0),
        initialBeamDirection: BeamDirection.RIGHT
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
        initialBeamDirection: BeamDirection.UP
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
        initialBeamDirection: BeamDirection.LEFT
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal([], actualBeams);
    }

    [Fact]
    public void BeamsDisappearMovingOutsideTheMapBoundariesOnSouth()
    {
      var map = SimpleSmallEmptyMapAnd(
        initialBeamCoordinate: new Coordinate(X: 0, Y: 2),
        initialBeamDirection: BeamDirection.DOWN
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
      BeamDirection initialBeamDirection
    )
    {
      return ContraptionMap.From(
        mapRows: SIMPLE_SMALL_EMPTY_MAP_ROWS,
        initialBeamCoordinate: initialBeamCoordinate,
        initialBeamDirection: initialBeamDirection
      );
    }
  }

  public class SimpleMapWithSingleMirror()
  {

    private readonly ContraptionMap map = ContraptionMap.From([
      @"..\",
      @"...",
      @"..."
    ]);

    [Fact]
    public void BeamsShouldStepOverAndChangeDirectionHittingMirror()
    {
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 2, Y: 1),
        expectedDirection: BeamDirection.DOWN,
        map: map
      );
    }

    [Fact]
    public void MoveBeamInDownDirection()
    {
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 2, Y: 2),
        expectedDirection: BeamDirection.DOWN,
        map: map
      );
    }

    [Fact]
    public void BeamsDisappearMovingOutsideTheMapBoundariesOnSouth()
    {
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
      map.MoveNextAllBeams();
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
        initialBeamDirection: BeamDirection.RIGHT
      );

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 0, Y: 1),
        expectedDirection: BeamDirection.DOWN,
        map: map
      );
    }

  }

  public class MapWithSomeMirrorsTest
  {

    private readonly static string[] MAP_WITH_SOME_MIRRORS_ROWS = [
      @".\./.\",
      @"......",
      @".\./..",
      @"../\..",
      @"......",
      @"/./\./"
    ];


    [Fact]
    public void Hit_NorthWestSouthEast_MirrorFromNorthShouldMoveBeamToRight()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 1, Y: 1),
        initialBeamDirection: BeamDirection.DOWN
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 2, Y: 2),
        expectedDirection: BeamDirection.RIGHT,
        map: map
      );
    }

    [Fact]
    public void Hit_SouthWestNorthEast_MirrorFromWestShouldMoveBeamToUp()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 2, Y: 2),
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 3, Y: 1),
        expectedDirection: BeamDirection.UP,
        map: map
      );
    }

    [Fact]
    public void Hit_SouthWestNorthEast_MirrorFromSouthShouldMoveBeamToRight()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 3, Y: 1),
        initialBeamDirection: BeamDirection.UP
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 4, Y: 0),
        expectedDirection: BeamDirection.RIGHT,
        map: map
      );
    }

    [Fact]
    public void Hit_NorthWestSouthEast_MirrorFromWestShouldMoveBeamToDown()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 4, Y: 0),
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 5, Y: 1),
        expectedDirection: BeamDirection.DOWN,
        map: map
      );
    }

    [Fact]
    public void Hit_SouthWestNorthEast_MirrorFromNorthShouldMoveBeamToLeft()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 5, Y: 4),
        initialBeamDirection: BeamDirection.DOWN
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 4, Y: 5),
        expectedDirection: BeamDirection.LEFT,
        map: map
      );
    }

    [Fact]
    public void Hit_NorthWestSouthEast_MirrorFromEastShouldMoveBeamToUp()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 4, Y: 5),
        initialBeamDirection: BeamDirection.LEFT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 3, Y: 4),
        expectedDirection: BeamDirection.UP,
        map: map
      );
    }

    [Fact]
    public void Hit_NorthWestSouthEast_MirrorFromSouthShouldMoveBeamToLeft()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 1, Y: 1),
        initialBeamDirection: BeamDirection.UP
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 0, Y: 0),
        expectedDirection: BeamDirection.LEFT,
        map: map
      );
    }

    [Fact]
    public void Hit_SouthWestNorthEast_MirrorFromEastShouldMoveBeamToDown()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 4, Y: 0),
        initialBeamDirection: BeamDirection.LEFT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 3, Y: 1),
        expectedDirection: BeamDirection.DOWN,
        map: map
      );
    }

    [Fact]
    public void HitAMirrorAndDisappearMovingOutsideTheMapBoundaries()
    {
      var map = MapWithSomeMirrorsAnd(
        initialBeamCoordinate: new(X: 1, Y: 5),
        initialBeamDirection: BeamDirection.LEFT
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
        initialBeamDirection: BeamDirection.UP
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 2, Y: 4),
        expectedDirection: BeamDirection.DOWN,
        map: map
      );
    }

    private ContraptionMap MapWithSomeMirrorsAnd(
      Coordinate initialBeamCoordinate,
      BeamDirection initialBeamDirection
    )
    {
      return ContraptionMap.From(
        mapRows: MAP_WITH_SOME_MIRRORS_ROWS,
        initialBeamCoordinate: initialBeamCoordinate,
        initialBeamDirection: initialBeamDirection
      );
    }
  }

  public class SmallMapWithSplittersTest()
  {

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
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 2, Y: 1),
        expectedDirection: BeamDirection.RIGHT,
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
        initialBeamDirection: BeamDirection.DOWN
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 1, Y: 2),
        expectedDirection: BeamDirection.DOWN,
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
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 2, Y: 0),
        expectedDirection: BeamDirection.UP,
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
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal(2, actualBeams.Count);
      Assert.Equal(new()
      {
        [new Coordinate(X: 1, Y: 0)] = BeamDirection.UP,
        [new Coordinate(X: 1, Y: 2)] = BeamDirection.DOWN
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
        initialBeamDirection: BeamDirection.LEFT
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal(2, actualBeams.Count);
      Assert.Equal(new()
      {
        [new Coordinate(X: 1, Y: 0)] = BeamDirection.UP,
        [new Coordinate(X: 1, Y: 2)] = BeamDirection.DOWN
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
        initialBeamDirection: BeamDirection.DOWN
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal(2, actualBeams.Count);
      Assert.Equal(new()
      {
        [new Coordinate(X: 0, Y: 1)] = BeamDirection.LEFT,
        [new Coordinate(X: 2, Y: 1)] = BeamDirection.RIGHT
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
        initialBeamDirection: BeamDirection.UP
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal(2, actualBeams.Count);
      Assert.Equal(new()
      {
        [new Coordinate(X: 0, Y: 1)] = BeamDirection.LEFT,
        [new Coordinate(X: 2, Y: 1)] = BeamDirection.RIGHT
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
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 1, Y: 1),
        expectedDirection: BeamDirection.DOWN,
        map: map
      );
    }

    [Fact]
    public void MoveMultipleBeamsSimultaneously()
    {
      var map = ContraptionMap.From(
        mapRows: [
          @".....",
          @".....",
          @"..|..",
          @".....",
          @".....",
        ],
        initialBeamCoordinate: new Coordinate(X: 1, Y: 2),
        initialBeamDirection: BeamDirection.RIGHT
      );

      // hit the splitter: two beams generated
      map.MoveNextAllBeams();
      Assert.Equal(new()
      {
        [new Coordinate(X: 2, Y: 1)] = BeamDirection.UP,
        [new Coordinate(X: 2, Y: 3)] = BeamDirection.DOWN
      }, map.GetExistingBeams());

      // move on both after split
      map.MoveNextAllBeams();
      Assert.Equal(new()
      {
        [new Coordinate(X: 2, Y: 0)] = BeamDirection.UP,
        [new Coordinate(X: 2, Y: 4)] = BeamDirection.DOWN
      }, map.GetExistingBeams());
    }

  }

  public class AdjacentElementsTest()
  {

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
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      AssertSingleBeam(
        expectedCoordinate: new Coordinate(X: 3, Y: 2),
        expectedDirection: BeamDirection.RIGHT,
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
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal([], actualBeams);
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
        initialBeamDirection: BeamDirection.RIGHT
      );

      map.MoveNextAllBeams();

      var actualBeams = map.GetExistingBeams();
      Assert.Equal(3, actualBeams.Count);
      Assert.Equal(new()
      {
        [new Coordinate(X: 0, Y: 0)] = BeamDirection.LEFT,
        [new Coordinate(X: 2, Y: 0)] = BeamDirection.RIGHT,
        [new Coordinate(X: 2, Y: 2)] = BeamDirection.RIGHT
      }, actualBeams);
    }

  }


  // TODO testcase: let disappear beam on a coordinate
  // already visited in the same direction

  // TODO testcase: handle multiple beam simultaneously
  // in the same coordinate (with different directions)
  [Fact(Skip = "next")]
  public void MultipleBeamCanBeInTheSameCoordinateWithDifferentDirections()
  {
    var map = ContraptionMap.From(
      mapRows: [
        @"/..\",
        @"...|",
        @"\../",
        @"....",
      ],
      initialBeamCoordinate: new Coordinate(X: 2, Y: 1),
      initialBeamDirection: BeamDirection.RIGHT
    );

    // hit the splitter and the adjacent mirrors
    map.MoveNextAllBeams();
    Assert.Equal(new()
    {
      [new Coordinate(X: 2, Y: 0)] = BeamDirection.LEFT,
      [new Coordinate(X: 2, Y: 2)] = BeamDirection.LEFT
    }, map.GetExistingBeams());

    // hit the mirror ending in the same coordinate
    map.MoveNextAllBeams();
    map.MoveNextAllBeams();
    Assert.Equal(new()
    {
      // ??
      //[new Coordinate(X: 0, Y: 1)] = BeamDirection.DOWN,
      //[new Coordinate(X: 0, Y: 1)] = BeamDirection.UP
    }, map.GetExistingBeams());
  }

  private static void AssertSingleBeam(
    Coordinate expectedCoordinate,
    BeamDirection expectedDirection,
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
