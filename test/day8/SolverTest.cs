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

  }

}
