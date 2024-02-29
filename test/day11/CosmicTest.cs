namespace aoc2023.day11;

using Xunit;

public class CosmicTest
{

  [Fact]
  public void CalculateShortestPathBetweenGalaxiesLength_FromNorthWestToSouthEast()
  {
    var cosmic = new Cosmic([]);
    int actual = cosmic.ShortestPathLengthBetweenCoordinates(new Coordinate(1, 6), new Coordinate(5, 11));
    Assert.Equal(9, actual);
  }

  [Fact]
  public void CalculateShortestPathBetweenGalaxiesLength_FromSouthEastToNorthWest()
  {
    var cosmic = new Cosmic([]);
    int actual = cosmic.ShortestPathLengthBetweenCoordinates(new Coordinate(5, 11), new Coordinate(1, 6));
    Assert.Equal(9, actual);
  }

}
