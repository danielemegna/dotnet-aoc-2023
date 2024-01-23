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

    [Fact]
    public void FileContent()
    {
      var input = File.ReadAllLines("day6/input.txt");
      var actual = solver.ParseRaces(input);
      Assert.Equal<Race[]>([
        new Race(DurationInMilliseconds: 56, RecordInMillimeters: 546),
        new Race(DurationInMilliseconds: 97, RecordInMillimeters: 1927),
        new Race(DurationInMilliseconds: 78, RecordInMillimeters: 1131),
        new Race(DurationInMilliseconds: 75, RecordInMillimeters: 1139)
      ], actual);
    }

    [Fact]
    public void AsSingleRace()
    {
      var actual = solver.ParseAsSingleRace(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(new Race(DurationInMilliseconds: 71530, RecordInMillimeters: 940200), actual);
    }
  }

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.WaysToWinFactor(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(4 * 8 * 9, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day6/input.txt");
      var actual = solver.WaysToWinFactor(input);
      Assert.Equal(1624896, actual);
    }

  }

  public class SecondPartTest : SolverTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.WaysToWinCount(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(71503, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day6/input.txt");
      var actual = solver.WaysToWinCount(input);
      Assert.Equal(-1, actual);
    }

  }

}