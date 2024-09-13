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

  [Fact]
  public void TiltOnNorthBiggerMapWithGreaterMovements()
  {
    var simpleMap = RocksMap.From([
      "...#",
      "....",
      "O.O.",
      ".O.O",
    ]);

    var tilted = simpleMap.TiltOnNorth();

    var expected = RocksMap.From([
      "OOO#",
      "...O",
      "....",
      "....",
    ]);
    Assert.Equal(tilted, expected);
  }

  [Fact]
  public void TiltOnNorthTheProvidedMapExample()
  {
    var tilted = map.TiltOnNorth();
    var expected = RocksMap.From(PROVIDED_EXAMPLE_NORTH_TILTED_INPUT_LINES);
    Assert.Equal(tilted, expected);
  }

  [Fact]
  public void TurnClockwiseSimpleMap()
  {
    var simpleMap = RocksMap.From([
      ".O",
      "#.",
    ]);

    var turned = simpleMap.TurnClockwise();

    var expected = RocksMap.From([
      "#.",
      ".O",
    ]);
    Assert.Equal(expected, turned);
  }

  [Fact]
  public void TurnClockwiseBiggerMap()
  {
    var biggerMap = RocksMap.From([
      "...#",
      "....",
      "O.O.",
      ".O.O",
    ]);

    var turned = biggerMap.TurnClockwise();

    var expected = RocksMap.From([
      ".O..",
      "O...",
      ".O..",
      "O..#",
    ]);
    Assert.Equal(expected, turned);
  }

  [Fact]
  public void TurnClockwiseMoreComplexMap()
  {
    var complexMap = RocksMap.From(PROVIDED_EXAMPLE_NORTH_TILTED_INPUT_LINES);

    var turned = complexMap.TurnClockwise();

    var expected = RocksMap.From([
      "##....OOOO",
      ".......OOO",
      "..OO#....O",
      "......#..O",
      ".......O#.",
      "##.#..O#.#",
      ".#....O#..",
      ".#.O#....O",
      ".....#....",
      "...O#..O#.",
    ]);
    Assert.Equal(expected, turned);
  }

}
