namespace aoc2023.day3;

using Xunit;

public class GearRatiosTest
{
  private readonly GearRatios solver = new();

  public class FirstPartTest : GearRatiosTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var input = new string[] {
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
      };

      var actual = solver.SumEngineParts(input);

      Assert.Equal(467 + 35 + 633 + 617 + 592 + 755 + 664 + 598, actual);
    }

    [Fact]
    public void SolveAnotherExampleWithNumbersAtTheEdges()
    {
      var input = new string[] {
        ".....739.....",
        "......@......",
        ".............",
        ".............",
        "44...........",
        ".#.........32",
        "..........*..",
        ".............",
        "....&........",
        ".....82......",
      };

      var actual = solver.SumEngineParts(input);

      Assert.Equal(739 + 44 + 32 + 82, actual);
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

  }

}
