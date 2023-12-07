namespace aoc2023.day2;

using Xunit;

public class CubeConundrumTest
{
  private readonly CubeConundrum solver = new();

  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
  ];

  public class FirstPartTest : CubeConundrumTest
  {
    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.SumOfPossibileGame(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(1 + 2 + 5, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var inputFromFile = File.ReadAllLines("day2/input.txt");
      var actual = solver.SumOfPossibileGame(inputFromFile);
      Assert.Equal(2541, actual);
    }
  }

  public class SecondPartTest : CubeConundrumTest
  {
    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.SumOfPowerOfMinimumNeededCubes(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(48 + 12 + 1560 + 630 + 36, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var inputFromFile = File.ReadAllLines("day2/input.txt");
      var actual = solver.SumOfPowerOfMinimumNeededCubes(inputFromFile);
      Assert.Equal(66016, actual);
    }

  }

}
