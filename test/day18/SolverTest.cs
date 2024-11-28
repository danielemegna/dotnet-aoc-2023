namespace aoc2023.day18;

using Xunit;

public class SolverTest
{

  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "R 6 (#70c710)",
    "D 5 (#0dc571)",
    "L 2 (#5713f0)",
    "D 2 (#d2c081)",
    "R 2 (#59c680)",
    "D 2 (#411b91)",
    "L 5 (#8ceee2)",
    "U 2 (#caa173)",
    "L 1 (#1b58a2)",
    "U 2 (#caa171)",
    "R 2 (#7807d2)",
    "U 3 (#a77fa3)",
    "L 2 (#015232)",
    "U 2 (#7a21e3)"
  ];

  [Fact(Skip = "WIP")]
  public void PartialSolutionWithTheProvidedExample()
  {
    var actual = Solver.TotalCubicMetersDugOutInTheEdgeWith(PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.Equal(38, actual);
  }

  [Fact(Skip = "WIP")]
  public void SolveWithTheProvidedExample()
  {
    var actual = Solver.TotalCubicMetersDugOutWith(PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.Equal(62, actual);
  }

}