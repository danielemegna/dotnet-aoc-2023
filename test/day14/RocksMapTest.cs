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

  [Fact]
  public void LoadOnNorthForEmptySpacesIsAlwaysZero()
  {
    Assert.Equal(0, map.LoadOnNorthAt(x: 1, y: 0));
    Assert.Equal(0, map.LoadOnNorthAt(x: 2, y: 0));
    Assert.Equal(0, map.LoadOnNorthAt(x: 0, y: 2));
    Assert.Equal(0, map.LoadOnNorthAt(x: 4, y: 7));
  }

  [Fact]
  public void LoadOnNorthForCubeRocksIsAlwaysZero()
  {
    Assert.Equal(0, map.LoadOnNorthAt(x: 5, y: 0));
    Assert.Equal(0, map.LoadOnNorthAt(x: 9, y: 0));
    Assert.Equal(0, map.LoadOnNorthAt(x: 5, y: 9));
  }

  [Fact]
  public void LoadOnNorthForRoundRocksDependsOnYPosition()
  {
    Assert.Equal(10, map.LoadOnNorthAt(x: 0, y: 0));
    Assert.Equal(9, map.LoadOnNorthAt(x: 2, y: 1));
    Assert.Equal(6, map.LoadOnNorthAt(x: 7, y: 4));
    Assert.Equal(3, map.LoadOnNorthAt(x: 7, y: 7));
    Assert.Equal(1, map.LoadOnNorthAt(x: 1, y: 9));
  }

}
