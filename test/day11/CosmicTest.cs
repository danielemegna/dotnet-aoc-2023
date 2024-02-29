namespace aoc2023.day11;

using Xunit;

public class CosmicTest
{

  [Fact]
  public void CalculateShortestPathBetweenGalaxiesLength_FromNorthWestToSouthEast()
  {
    Cosmic cosmic = new Cosmic([new Coordinate(1, 6), new Coordinate(5, 11)]);
    int actual = cosmic.ShortestPathBetweenGalaxiesLength(new Coordinate(1, 6), new Coordinate(5, 11));
    Assert.Equal(9, actual);
  }

}
