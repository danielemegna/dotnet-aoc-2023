namespace aoc2023.day2;

using Xunit;

public class GameParserTest
{
  [Fact]
  public void ProperlyParseGameId()
  {
    var actual = GameParser.ParseGame(CubeConundrumTest.PROVIDED_EXAMPLE_INPUT_LINES[0]);
    Assert.Equal(1, actual.Id);
    actual = GameParser.ParseGame(CubeConundrumTest.PROVIDED_EXAMPLE_INPUT_LINES[1]);
    Assert.Equal(2, actual.Id);
    actual = GameParser.ParseGame(CubeConundrumTest.PROVIDED_EXAMPLE_INPUT_LINES[4]);
    Assert.Equal(5, actual.Id);
  }

  [Fact]
  public void ProperlyParseGameIdWithMoreThanTwoDigits()
  {
    var actual = GameParser.ParseGame("Game 15: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
    Assert.Equal(15, actual.Id);
  }

  [Fact]
  public void ProperlyGetMaxCountForColorCube()
  {
    var actual = GameParser.ParseGame(CubeConundrumTest.PROVIDED_EXAMPLE_INPUT_LINES[0]);
    Assert.Equal(6, actual.MaxCountInSet(CubeColor.BLUE));
    Assert.Equal(4, actual.MaxCountInSet(CubeColor.RED));
    actual = GameParser.ParseGame(CubeConundrumTest.PROVIDED_EXAMPLE_INPUT_LINES[2]);
    Assert.Equal(20, actual.MaxCountInSet(CubeColor.RED));
    Assert.Equal(13, actual.MaxCountInSet(CubeColor.GREEN));
    actual = GameParser.ParseGame(CubeConundrumTest.PROVIDED_EXAMPLE_INPUT_LINES[3]);
    Assert.Equal(15, actual.MaxCountInSet(CubeColor.BLUE));
    Assert.Equal(14, actual.MaxCountInSet(CubeColor.RED));
  }
}
