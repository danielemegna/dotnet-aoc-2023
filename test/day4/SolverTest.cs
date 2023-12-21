namespace aoc2023.day4;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
    "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
    "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
    "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
    "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
    "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
  ];

  private readonly Solver solver = new();

  public class ParsingTest : SolverTest
  {
    [Fact(Skip = "WIP")]
    public void ProvidedExample()
    {
      var actual = solver.ParseScratchcards(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(6, actual.Length);
      Assert.Equal(new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]), actual[0]);
    }
  }

  public class FirstPartTest : SolverTest
  {

    [Fact(Skip = "WIP")]
    public void SolveTheProvidedExample()
    {
      var actual = solver.SumPointsOfScratchcards(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(8 + 2 + 2 + 1 + 0 + 0, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day4/input.txt");
      var actual = solver.SumPointsOfScratchcards(input);
      Assert.Equal(-1, actual);
    }

  }

}
