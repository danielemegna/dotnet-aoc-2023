namespace aoc2023.day9;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "0 3 6 9 12 15",
    "1 3 6 10 15 21",
    "10 13 16 21 30 45",
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheFirstProvidedExample()
    {
      var actual = solver.SumOfNextHistoryValues(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(18 + 28 + 68, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day9/input.txt");
      var actual = solver.SumOfNextHistoryValues(input);
      Assert.Equal(2008960228, actual);
    }

  }

}
