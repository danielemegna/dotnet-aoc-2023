namespace aoc2023.day11;

using Xunit;

public class SolverTest
{

  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "...#......",
    ".......#..",
    "#.........",
    "..........",
    "......#...",
    ".#........",
    ".........#",
    "..........",
    ".......#..",
    "#...#....."
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveProvidedExample()
    {
      var actual = solver.SumOfShortestPathBetweenGalaxies(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(374, actual);
    }

    [Fact(Skip = "Wip")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day11/input.txt");
      var actual = solver.SumOfShortestPathBetweenGalaxies(input);
      Assert.Equal(-1, actual);
    }

  }

}
