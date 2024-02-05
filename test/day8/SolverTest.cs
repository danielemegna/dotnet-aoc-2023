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

  public static readonly string[] THIRD_PROVIDED_EXAMPLE_INPUT_LINES = [
    "LR",
    "",
    "AAA = (AAB, XXX)",
    "AAB = (XXX, AAZ)",
    "AAZ = (AAB, XXX)",
    "BBA = (BBB, XXX)",
    "BBB = (BBC, BBC)",
    "BBC = (BBZ, BBZ)",
    "BBZ = (BBB, BBB)",
    "XXX = (XXX, XXX)"
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheFirstProvidedExample()
    {
      var actual = solver.StepsToReachDestination(FIRST_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(2, actual);
    }

    [Fact]
    public void SolveTheSecondProvidedExample()
    {
      var actual = solver.StepsToReachDestination(SECOND_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(6, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day8/input.txt");
      var actual = solver.StepsToReachDestination(input);
      Assert.Equal(17263, actual);
    }

  }

  public class SecondPartTest : SolverTest
  {
    [Fact]
    public void SolveTheFirstProvidedExample()
    {
      var actual = solver.StepsToReachDestinationWithEveryGhost(FIRST_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(2, actual);
    }

    [Fact]
    public void SolveTheSecondProvidedExample()
    {
      var actual = solver.StepsToReachDestinationWithEveryGhost(SECOND_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(6, actual);
    }

    [Fact]
    public void SolveTheThirdProvidedExample()
    {
      var actual = solver.StepsToReachDestinationWithEveryGhost(THIRD_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(6, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day8/input.txt");
      var actual = solver.StepsToReachDestinationWithEveryGhost(input);
      Assert.Equal(-1, actual);
    }
  }

}
