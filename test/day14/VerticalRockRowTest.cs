namespace aoc2023.day14;

using Xunit;
using static MapObject;

public class VerticalRockRowTest
{

  [Fact]
  public void TiltRowOfSpaces()
  {
    var row = new VerticalRockRow([EMPTY_SPACE, EMPTY_SPACE]);
    row.Tilt();

    var expected = new VerticalRockRow([EMPTY_SPACE, EMPTY_SPACE]);
    Assert.Equal(expected, row);
  }

  [Fact]
  public void TiltRowWithSingleRoundRock()
  {
    var row = new VerticalRockRow([EMPTY_SPACE, ROUND_ROCK]);
    row.Tilt();

    var expected = new VerticalRockRow([ROUND_ROCK, EMPTY_SPACE]);
    Assert.Equal(expected, row);
  }

  [Fact]
  public void TiltRowWithSingleCubeRock()
  {
    var row = new VerticalRockRow([EMPTY_SPACE, CUBE_ROCK]);
    row.Tilt();

    var expected = new VerticalRockRow([EMPTY_SPACE, CUBE_ROCK]);
    Assert.Equal(expected, row);
  }

  [Fact]
  public void TiltRowWithMultipleRoundRock()
  {
    var row = new VerticalRockRow([EMPTY_SPACE, EMPTY_SPACE, ROUND_ROCK, EMPTY_SPACE, ROUND_ROCK]);
    row.Tilt();

    var expected = new VerticalRockRow([ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE, EMPTY_SPACE, EMPTY_SPACE]);
    Assert.Equal(expected, row);
  }

  [Fact]
  public void TiltMoreComplexRow()
  {
    var row = new VerticalRockRow([
      EMPTY_SPACE, EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK, EMPTY_SPACE, EMPTY_SPACE, ROUND_ROCK,
      ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK
    ]);
    row.Tilt();

    var expected = new VerticalRockRow([
      ROUND_ROCK, EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE,
      EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK
    ]);
    Assert.Equal(expected, row);
  }

  [Fact]
  public void LoadZeroForEmptySpacesAndCubeRocks()
  {
    Assert.Equal(0, new VerticalRockRow([EMPTY_SPACE]).GetLoad());
    Assert.Equal(0, new VerticalRockRow([CUBE_ROCK]).GetLoad());
    Assert.Equal(0, new VerticalRockRow([EMPTY_SPACE, CUBE_ROCK]).GetLoad());
    Assert.Equal(0, new VerticalRockRow([CUBE_ROCK, EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK]).GetLoad());
  }

  [Fact]
  public void LoadOneForSingleRoundRock()
  {
    Assert.Equal(1, new VerticalRockRow([ROUND_ROCK]).GetLoad());
  }

  [Fact]
  public void LoadMoreThanOneWhenRowIsLonger()
  {
    Assert.Equal(2, new VerticalRockRow([ROUND_ROCK, EMPTY_SPACE]).GetLoad());
    Assert.Equal(2, new VerticalRockRow([ROUND_ROCK, CUBE_ROCK]).GetLoad());
    Assert.Equal(3, new VerticalRockRow([ROUND_ROCK, EMPTY_SPACE, EMPTY_SPACE]).GetLoad());
    Assert.Equal(4, new VerticalRockRow([ROUND_ROCK, CUBE_ROCK, CUBE_ROCK, CUBE_ROCK]).GetLoad());
    Assert.Equal(5, new VerticalRockRow([ROUND_ROCK, CUBE_ROCK, EMPTY_SPACE, CUBE_ROCK, EMPTY_SPACE]).GetLoad());
  }

  [Fact]
  public void LoadAsSumOfRoundRockLoads()
  {
    Assert.Equal(2 + 1, new VerticalRockRow([ROUND_ROCK, ROUND_ROCK]).GetLoad());
    Assert.Equal(3 + 1, new VerticalRockRow([ROUND_ROCK, CUBE_ROCK, ROUND_ROCK]).GetLoad());
    Assert.Equal(6 + 5 + 2, new VerticalRockRow([
      ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, EMPTY_SPACE
    ]).GetLoad());
    Assert.Equal(14 + 10 + 9 + 4 + 3, new VerticalRockRow([
      ROUND_ROCK, EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE,
      EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK
    ]).GetLoad());
  }


  [Fact]
  public void Equality()
  {
    var row = new VerticalRockRow([EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, EMPTY_SPACE]);
    var anotherRow = new VerticalRockRow([ROUND_ROCK, CUBE_ROCK, EMPTY_SPACE, ROUND_ROCK]);
    var anotherCopyOfRow = new VerticalRockRow([EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, EMPTY_SPACE]);

    Assert.Equal(row, row);
    Assert.Same(row, row);

    Assert.Equal(row, anotherCopyOfRow);
    Assert.Equal(anotherCopyOfRow, row);
    Assert.False(row == anotherCopyOfRow);
    Assert.NotSame(row, anotherCopyOfRow);
    Assert.Equal(row.GetHashCode(), anotherCopyOfRow.GetHashCode());

    Assert.NotEqual(row, anotherRow);
    Assert.NotEqual(anotherRow, anotherCopyOfRow);
    Assert.NotEqual(row.GetHashCode(), anotherRow.GetHashCode());
  }

  [Fact]
  public void CustomToString()
  {
    var row = new VerticalRockRow([EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK, EMPTY_SPACE]);
    Assert.Equal("[.O#.]", row.ToString());

    row = new VerticalRockRow([
      EMPTY_SPACE, EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK, EMPTY_SPACE, EMPTY_SPACE, ROUND_ROCK,
      ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK
    ]);
    Assert.Equal("[..O#..OO.#O.O#]", row.ToString());

    row = new VerticalRockRow([
      ROUND_ROCK, EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE,
      EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK
    ]);
    Assert.Equal("[O..#OO...#OO.#]", row.ToString());
  }

  [Fact]
  public void GetObjectAtIndex()
  {
    var row = new VerticalRockRow([EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK, EMPTY_SPACE]);
    Assert.Equal(EMPTY_SPACE, row.At(0));
    Assert.Equal(ROUND_ROCK, row.At(1));
    Assert.Equal(CUBE_ROCK, row.At(2));
    Assert.Equal(EMPTY_SPACE, row.At(3));
  }

}
