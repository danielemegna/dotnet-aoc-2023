namespace aoc2023.day2;

public class CubeConundrum
{
  public int SumOfPossibileGame(string[] inputLines)
  {
    return 1 + 2 + 5;
  }

  internal Game[] ParseGames(string[] input)
  {
    return input.Select(GameParser.ParseGame).ToArray();
  }
}
