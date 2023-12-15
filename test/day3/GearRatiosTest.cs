namespace aoc2023.day3;

using Xunit;

public class GearRatiosTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "467..114..",
    "...*......",
    "..35..633.",
    "......#...",
    "617*......",
    ".....+.58.",
    "..592.....",
    "......755.",
    "...$.*....",
    ".664.598..",
  ];

  private readonly GearRatios solver = new();

  public class FirstPartTest : GearRatiosTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.SumEngineParts(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(467 + 35 + 633 + 617 + 592 + 755 + 664 + 598, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day3/input.txt");
      var actual = solver.SumEngineParts(input);
      Assert.Equal(550934, actual);
    }

  }

  public class SecondPartTest : GearRatiosTest
  {
    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.SumGearRatios(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal((467 * 35) + (755 * 598), actual);
    }

  }

}
