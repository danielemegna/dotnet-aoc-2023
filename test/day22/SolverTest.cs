namespace aoc2023.day22;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "1,0,1~1,2,1",
    "0,0,2~2,0,2",
    "0,2,3~2,2,3",
    "0,0,4~0,2,4",
    "2,0,5~2,2,5",
    "0,1,6~2,1,6",
    "1,1,8~1,1,9",
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.CountSafeToDisintegrateBricks(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(5, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day22/input.txt");
      var actual = solver.CountSafeToDisintegrateBricks(input);
      Assert.Equal(465, actual);
    }

  }
}
