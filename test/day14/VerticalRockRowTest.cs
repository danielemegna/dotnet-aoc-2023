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
      EMPTY_SPACE, EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK, EMPTY_SPACE,EMPTY_SPACE, ROUND_ROCK,
      ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK
    ]);
    row.Tilt();

    var expected = new VerticalRockRow([
      ROUND_ROCK, EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK,ROUND_ROCK, EMPTY_SPACE,
      EMPTY_SPACE, EMPTY_SPACE, CUBE_ROCK, ROUND_ROCK, ROUND_ROCK, EMPTY_SPACE, CUBE_ROCK
    ]);
    Assert.Equal(expected, row);
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
}
