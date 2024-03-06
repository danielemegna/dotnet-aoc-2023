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

  public static readonly string[] LARGER_COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES = [
    ".F----7F7F7F7F-7....",
    ".|F--7||||||||FJ....",
    ".||.FJ||||||||L7....",
    "FJL7L7LJLJ||LJ.L-7..",
    "L--J.L7...LJS7F-7L7.",
    "....F-J..F7FJ|L7L7L7",
    "....L7.F7||L7|.L7L7|",
    ".....|FJLJ|FJ|F7|.LJ",
    "....FJL-7.||.||||...",
    "....L---J.LJ.LJLJ..."
  ];

  public static readonly string[] VERY_COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES = [
    "FF7FSF7F7F7F7F7F---7",
    "L|LJ||||||||||||F--J",
    "FL-7LJLJ||||||LJL-77",
    "F--JF--7||LJLJ7F7FJ-",
    "L---JF-JLJ.||-FJLJJ7",
    "|F|F-JF---7F7-L7L|7|",
    "|FFJF7L7F-JF7|JL---7",
    "7-L-JL7||F7|L7F-7F7|",
    "L.L7LFJ|||||FJL7||LJ",
    "L7JLJL-JLJLJL--JLJ.L"
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheSimpleProvidedExample()
    {
      var actual = solver.FarthestPointFromStartDistance(SIMPLE_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(4, actual);
    }

    [Fact]
    public void SolveTheComplexProvidedExample()
    {
      var actual = solver.FarthestPointFromStartDistance(COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(8, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day10/input.txt");
      var actual = solver.FarthestPointFromStartDistance(input);
      Assert.Equal(6690, actual);
    }

  }

}
