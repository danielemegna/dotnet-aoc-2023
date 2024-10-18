namespace aoc2023.day16;

using Xunit;

public class ContraptionMapTest
{

  [Fact]
  public void GetExistingBeamsOnNewMap()
  {
    string[] simpleMapStrings = [
      "...",
      "...",
      "..."
    ];

    var map = ContraptionMap.From(simpleMapStrings);
    var actualBeams = map.GetExistingBeams();

    var expectedBeams = new Dictionary<Coordinate, ContraptionMap.BeamDirection>()
    {
      [new Coordinate(X: 0, Y: 0)] = ContraptionMap.BeamDirection.RIGHT
    };
    Assert.Equal(expectedBeams, actualBeams);
  }

}
