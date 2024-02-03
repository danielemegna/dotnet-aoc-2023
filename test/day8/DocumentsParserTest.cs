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
        { "AAA".GetHashCode(), ("BBB".GetHashCode(), "CCC".GetHashCode() ) },
        { "BBB".GetHashCode(), ("DDD".GetHashCode(), "EEE".GetHashCode() ) },
        { "CCC".GetHashCode(), ("ZZZ".GetHashCode(), "GGG".GetHashCode() ) },
        { "DDD".GetHashCode(), ("DDD".GetHashCode(), "DDD".GetHashCode() ) },
        { "EEE".GetHashCode(), ("EEE".GetHashCode(), "EEE".GetHashCode() ) },
        { "GGG".GetHashCode(), ("GGG".GetHashCode(), "GGG".GetHashCode() ) },
        { "ZZZ".GetHashCode(), ("ZZZ".GetHashCode(), "ZZZ".GetHashCode() ) },
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
        { "AAA".GetHashCode(), ("BBB".GetHashCode(), "BBB".GetHashCode() ) },
        { "BBB".GetHashCode(), ("AAA".GetHashCode(), "ZZZ".GetHashCode() ) },
        { "ZZZ".GetHashCode(), ("ZZZ".GetHashCode(), "ZZZ".GetHashCode() ) },
      };
    Assert.Equal(expectedMoves, actual.Moves);
    Assert.Equal(expectedNetwork, actual.Network);
  }


}
