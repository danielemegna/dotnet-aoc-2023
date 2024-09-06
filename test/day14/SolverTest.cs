namespace aoc2023.day14;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "O....#....",
    "O.OO#....#",
    ".....##...",
    "OO.#O....O",
    ".O.....O#.",
    "O.#..O.#.#",
    "..O..#O..O",
    ".......O..",
    "#....###..",
    "#OO..#....",
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.TotalLoadOnNorthTilting(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(136, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day14/input.txt");
      var actual = solver.TotalLoadOnNorthTilting(input);
      Assert.Equal(107053, actual);
    }

  }

}
