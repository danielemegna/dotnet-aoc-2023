namespace aoc2023.day16;

using Xunit;

public class ContraptionMapTest
{
  private readonly ContraptionMap simpleSmallEmptyMap = ContraptionMap.From([
    "...",
    "...",
    "..."
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
  public void BeamsDisappearMovingOutsideTheMapBoundaries()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    simpleSmallEmptyMap.MoveNextAllBeams();
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    Assert.Equal([], actualBeams);
  }

}
