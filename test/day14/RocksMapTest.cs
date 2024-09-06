namespace aoc2023.day14;

using Xunit;

public class RocksMapTest
{

  public static readonly string[] PROVIDED_EXAMPLE_NORTH_TILTED_INPUT_LINES = [
    "OOOO.#.O..",
    "OO..#....#",
    "OO..O##..O",
    "O..#.OO...",
    "........#.",
    "..#....#.#",
    "..O..#.O.O",
    "..O.......",
    "#....###..",
    "#....#...."
  ];

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

  [Fact]
  public void GetTotalLoadOnNorth()
  {
    Assert.Equal(
      10 + (9 * 3) + (7 * 4) + (6 * 2) + (5 * 2) + (4 * 3) + (3 * 1) + (1 * 2),
      map.TotalLoadOnNorth()
    );
    var tiltedRocksMap = RocksMap.From(PROVIDED_EXAMPLE_NORTH_TILTED_INPUT_LINES);
    Assert.Equal(136, tiltedRocksMap.TotalLoadOnNorth());
  }

  [Fact]
  public void Equality()
  {
    var anotherCopyOfMap = RocksMap.From(SolverTest.PROVIDED_EXAMPLE_INPUT_LINES);
    var anotherMap = RocksMap.From(PROVIDED_EXAMPLE_NORTH_TILTED_INPUT_LINES);

    Assert.Equal(map, map);
    Assert.Same(map, map);

    Assert.Equal(map, anotherCopyOfMap);
    Assert.Equal(anotherCopyOfMap, map);
    Assert.False(map == anotherCopyOfMap);
    Assert.NotSame(map, anotherCopyOfMap);
    Assert.Equal(map.GetHashCode(), anotherCopyOfMap.GetHashCode());

    Assert.NotEqual(map, anotherMap);
    Assert.NotEqual(anotherMap, anotherCopyOfMap);
    Assert.NotEqual(map.GetHashCode(), anotherMap.GetHashCode());
  }

  [Fact]
  public void TiltOnNorthASimple2x2Map()
  {
    var simpleMap = RocksMap.From([
      ".O",
      "O.",
    ]);

    var tilted = simpleMap.TiltOnNorth();

    var expected = RocksMap.From([
      "OO",
      "..",
    ]);
    Assert.Equal(tilted, expected);
  }

  [Fact]
  public void TiltOnNorthLargerMapHandlingCubeRocks()
  {
    var simpleMap = RocksMap.From([
      "..#.",
      "#OO#",
    ]);

    var tilted = simpleMap.TiltOnNorth();

    var expected = RocksMap.From([
      ".O#.",
      "#.O#",
    ]);
    Assert.Equal(tilted, expected);
  }

  [Fact]
  public void TiltOnNorthBiggerMapWithMoreThanTwoRowsWithOneMove()
  {
    var simpleMap = RocksMap.From([
      "O#..",
      "...#",
      "OO..",
      "...O",
    ]);

    var tilted = simpleMap.TiltOnNorth();

    var expected = RocksMap.From([
      "O#..",
      "OO.#",
      "...O",
      "....",
    ]);
    Assert.Equal(tilted, expected);
  }

  [Fact(Skip = "WIP")]
  public void TiltOnNorthTheProvidedMapExample()
  {
    var tilted = map.TiltOnNorth();
    var expected = RocksMap.From(PROVIDED_EXAMPLE_NORTH_TILTED_INPUT_LINES);
    Assert.Equal(tilted, expected);
  }

}
