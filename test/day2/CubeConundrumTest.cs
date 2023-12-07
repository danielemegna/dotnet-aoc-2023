namespace aoc2023.day2;

using Xunit;

public class CubeConundrumTest
{
  private readonly CubeConundrum solver = new();

  private readonly string[] ProvidedExampleInput = [
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
      var actual = solver.SumOfPossibileGame(ProvidedExampleInput);
      Assert.Equal(1 + 2 + 5, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var inputFromFile = File.ReadAllLines("day2/input.txt");
      var actual = solver.SumOfPossibileGame(inputFromFile);
      Assert.Equal(999, actual);
    }

    public class ParseProvidedExample : CubeConundrumTest
    {
      [Fact]
      public void ProperlyParseGameId()
      {
        var actual = solver.ParseGames(ProvidedExampleInput);

        Assert.Equal(5, actual.Length);
        Assert.Equal(1, actual[0].Id);
        Assert.Equal(2, actual[1].Id);
        Assert.Equal(5, actual[4].Id);
      }

      [Fact]
      public void ProperlyGetMaxCountForColorCube()
      {
        var games = solver.ParseGames(ProvidedExampleInput);

        Assert.Equal(6, games[0].MaxCountInSet(CubeColor.BLUE));
        Assert.Equal(4, games[0].MaxCountInSet(CubeColor.RED));
        Assert.Equal(3, games[1].MaxCountInSet(CubeColor.GREEN));
        Assert.Equal(20, games[2].MaxCountInSet(CubeColor.RED));
        Assert.Equal(13, games[2].MaxCountInSet(CubeColor.GREEN));
        Assert.Equal(15, games[3].MaxCountInSet(CubeColor.BLUE));
        Assert.Equal(6, games[4].MaxCountInSet(CubeColor.RED));
      }
    }

  }

  public class SecondPartTest : CubeConundrumTest
  {


  }

}
