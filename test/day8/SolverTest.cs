namespace aoc2023.day8;

using Xunit;

public class SolverTest
{
  public static readonly string[] FIRST_PROVIDED_EXAMPLE_INPUT_LINES = [
    "RL",
    "",
    "AAA = (BBB, CCC)",
    "BBB = (DDD, EEE)",
    "CCC = (ZZZ, GGG)",
    "DDD = (DDD, DDD)",
    "EEE = (EEE, EEE)",
    "GGG = (GGG, GGG)",
    "ZZZ = (ZZZ, ZZZ)"
  ];

  public static readonly string[] SECOND_PROVIDED_EXAMPLE_INPUT_LINES = [
    "LLR",
    "",
    "AAA = (BBB, BBB)",
    "BBB = (AAA, ZZZ)",
    "ZZZ = (ZZZ, ZZZ)",
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void ParseFirstProvidedExample()
    {
      Documents actual = solver.ParseDocuments(FIRST_PROVIDED_EXAMPLE_INPUT_LINES);

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
      Documents actual = solver.ParseDocuments(SECOND_PROVIDED_EXAMPLE_INPUT_LINES);

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

}
