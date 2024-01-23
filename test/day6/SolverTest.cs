namespace aoc2023.day6;

using Xunit;

public class SolverTest
{

  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "Time:      7  15   30",
    "Distance:  9  40  200"
  ];

  private readonly Solver solver = new();

  public class ParsingTest : SolverTest
  {
    [Fact]
    public void ProvidedExample()
    {
      var actual = solver.ParseRaces(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal<Race[]>([
        new Race(DurationInMilliseconds: 7, RecordInMillimeters: 9),
        new Race(DurationInMilliseconds: 15, RecordInMillimeters: 40),
        new Race(DurationInMilliseconds: 30, RecordInMillimeters: 200)
      ], actual);
    }
  }

  public class FirstPartTest : SolverTest
  {

    [Fact(Skip = "WIP")]
    public void SolveTheProvidedExample()
    {
      var actual = solver.WinsFactor(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(4 * 8 * 9, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day6/input.txt");
      var actual = solver.WinsFactor(input);
      Assert.Equal(-1, actual);
    }

  }

}