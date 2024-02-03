namespace aoc2023.day8;

using Xunit;

public class DocumentsParserTest
{
  private readonly DocumentsParser parser = new();

  [Fact]
  public void ParseFirstProvidedExample()
  {
    Documents actual = parser.Parse(SolverTest.FIRST_PROVIDED_EXAMPLE_INPUT_LINES);

    Move[] expectedMoves = [Move.RIGHT, Move.LEFT];
    Dictionary<int, (int, int)> expectedNetwork = new() {
        { 111, (222, 333) },
        { 222, (444, 555) },
        { 333, (0, 777) },
        { 444, (444, 444) },
        { 555, (555, 555) },
        { 777, (777, 777) },
        { 0, (0, 0) },
      };
    Assert.Equal(expectedMoves, actual.Moves);
    Assert.Equal(expectedNetwork, actual.Network);
  }

  [Fact]
  public void ParseSecondProvidedExample()
  {
    Documents actual = parser.Parse(SolverTest.SECOND_PROVIDED_EXAMPLE_INPUT_LINES);

    Move[] expectedMoves = [Move.LEFT, Move.LEFT, Move.RIGHT];
    Dictionary<int, (int, int)> expectedNetwork = new() {
        { 111, (222, 222) },
        { 222, (111, 0) },
        { 0, (0, 0) },
      };
    Assert.Equal(expectedMoves, actual.Moves);
    Assert.Equal(expectedNetwork, actual.Network);
  }


}
