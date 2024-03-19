namespace aoc2023.day12;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "???.### 1,1,3",
    ".??..??...?##. 1,1,3",
    "?#?#?#?#?#?#?#? 1,3,1,6",
    "????.#...#... 4,1,1",
    "????.######..#####. 1,6,5",
    "?###???????? 3,2,1"
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.SumOfPossibleArrangements(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(1 + 4 + 1 + 1 + 4 + 10, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day12/input.txt");
      var actual = solver.SumOfPossibleArrangements(input);
      Assert.Equal(7260, actual);
    }

  }

}
