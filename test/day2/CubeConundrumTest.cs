namespace aoc2023.day2;

using Xunit;

public class CubeConundrumTest
{
  private readonly CubeConundrum solver = new();

  public class FirstPartTest : CubeConundrumTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var input = new string[] {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
      };

      var actual = solver.SumOfPossibileGame(input);

      Assert.Equal(1 + 2 + 5, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day2/input.txt");
      var actual = solver.SumOfPossibileGame(input);
      Assert.Equal(999, actual);
    }

    [Fact]
    public void ParseProvidedExample()
    {
      var input = new string[] {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
      };

      var actual = solver.ParseGames(input);

      Assert.Equal(5, actual.Length);
      Assert.Equal(1, actual[0].Id);
      Assert.Equal(2, actual[1].Id);
      Assert.Equal(5, actual[4].Id);
    }

  }

  public class SecondPartTest : CubeConundrumTest
  {


  }

}
