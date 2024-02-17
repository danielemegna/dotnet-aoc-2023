namespace aoc2023.day10;

using Xunit;

public class SolverTest
{

  public static readonly string[] SIMPLE_PROVIDED_EXAMPLE_INPUT_LINES = [
    ".....",
    ".S-7.",
    ".|.|.",
    ".L-J.",
    "....."
  ];

  public static readonly string[] COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES = [
    "..F7.",
    ".FJ|.",
    "SJ.L7",
    "|F--J",
    "LJ..."
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact(Skip = "WIP")]
    public void SolveTheSimpleProvidedExample()
    {
      var actual = solver.FarthestPointFromStartDistance(SIMPLE_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(4, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveTheComplexProvidedExample()
    {
      var actual = solver.FarthestPointFromStartDistance(COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(8, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day10/input.txt");
      var actual = solver.FarthestPointFromStartDistance(input);
      Assert.Equal(-1, actual);
    }

  }

}
