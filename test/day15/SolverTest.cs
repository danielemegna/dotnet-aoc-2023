namespace aoc2023.day15;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7",
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.SumOfHashAlgorithmResultsFor(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(1320, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day15/input.txt");
      var actual = solver.SumOfHashAlgorithmResultsFor(input);
      Assert.Equal(-1, actual);
    }

  }

}
