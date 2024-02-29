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

  [Fact]
  public void SumShortestPathForThreeGalaxies()
  {
    var cosmic = new Cosmic([new Coordinate(0, 0), new Coordinate(0, 5), new Coordinate(1, 9)]);
    int actual = cosmic.SumOfShortestPathsBetweenGalaxies();
    Assert.Equal(5 + 10 + 5, actual);
  }

  [Fact]
  public void SumShortestPathForAdventExample()
  {
    var cosmic = new Cosmic([new Coordinate(0, 0), new Coordinate(0, 5), new Coordinate(1, 9),
      new Coordinate(4, 12), new Coordinate(5, 1), new Coordinate(6, 8), new Coordinate(9, 0),
      new Coordinate(10, 9), new Coordinate(11, 4)]);
    int actual = cosmic.SumOfShortestPathsBetweenGalaxies();
    Assert.Equal(374, actual);
  }
}
