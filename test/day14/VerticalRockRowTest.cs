namespace aoc2023.day14;

using Xunit;

public class VerticalRockRowTest
{

  [Fact]
  public void DoNotSortRowOfSpaces() {
    var row = new VerticalRockRow([MapObject.EMPTY_SPACE, MapObject.EMPTY_SPACE]);
    row.Sort();

    var expected = new VerticalRockRow([MapObject.EMPTY_SPACE, MapObject.EMPTY_SPACE]);
    Assert.Equal(expected, row);
  }

  [Fact]
  public void Equality()
  {
    var row = new VerticalRockRow([MapObject.EMPTY_SPACE, MapObject.CUBE_ROCK, MapObject.ROUND_ROCK, MapObject.EMPTY_SPACE]);
    var anotherRow = new VerticalRockRow([MapObject.ROUND_ROCK, MapObject.CUBE_ROCK, MapObject.EMPTY_SPACE, MapObject.ROUND_ROCK]);
    var anotherCopyOfRow = new VerticalRockRow([MapObject.EMPTY_SPACE, MapObject.CUBE_ROCK, MapObject.ROUND_ROCK, MapObject.EMPTY_SPACE]);

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
