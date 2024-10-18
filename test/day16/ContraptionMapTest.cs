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
  public void GetExistingBeamsOnNewMap()
  {
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 0, Y: 0)] = ContraptionMap.BeamDirection.RIGHT
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

  [Fact]
  public void GetExistingBeamsAfterMoveNextAllBeams()
  {
    simpleSmallEmptyMap.MoveNextAllBeams();
    var actualBeams = simpleSmallEmptyMap.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 1, Y: 0)] = ContraptionMap.BeamDirection.RIGHT
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

}
