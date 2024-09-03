namespace aoc2023.day14;

using Xunit;

public class RocksMapTest
{

  private readonly RocksMap map = RocksMap.From(SolverTest.PROVIDED_EXAMPLE_INPUT_LINES);

  [Fact]
  public void GetMapObjectsAtCoordinates()
  {
    Assert.Equal(MapObject.ROUND_ROCK, map.At(x: 0, y: 0));
    Assert.Equal(MapObject.EMPTY_SPACE, map.At(x: 1, y: 0));
    Assert.Equal(MapObject.CUBE_ROCK, map.At(x: 5, y: 0));

    Assert.Equal(MapObject.ROUND_ROCK, map.At(x: 7, y: 4));
    Assert.Equal(MapObject.EMPTY_SPACE, map.At(x: 4, y: 7));
    Assert.Equal(MapObject.CUBE_ROCK, map.At(x: 5, y: 9));
  }

}