namespace aoc2023.day16;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    @".|...\....",
    @"|.-.\.....",
    @".....|-...",
    @"........|.",
    @"..........",
    @".........\",
    @"..../.\\..",
    @".-.-/..|..",
    @".|....-|.\",
    @"..//.|....",
  ];

  private readonly Solver solver = new();

  [Fact]
  public void SolveTheProvidedExample()
  {
    var actual = solver.EnergizedTilesTotalCountFor(PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.Equal(46, actual);
  }

  [Fact]
  public void SolveWithFile()
  {
    var input = File.ReadAllLines("day16/input.txt");
    var actual = solver.EnergizedTilesTotalCountFor(input);
    Assert.Equal(8323, actual);
  }

}
