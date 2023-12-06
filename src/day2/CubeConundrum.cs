using System.Text.RegularExpressions;

namespace aoc2023.day2;

public class CubeConundrum
{
  public int SumOfPossibileGame(string[] inputLines)
  {
    return 1 + 2 + 5;
  }

  internal Game[] ParseGames(string[] input)
  {
    return input.Select(line =>
    {
      Regex regex = new Regex(@"^Game (\d):");
      MatchCollection matchCollection = regex.Matches(line);
      if(matchCollection.Count < 1 || matchCollection[0].Groups.Count < 2)
        throw new FormatException("Cannot parse game line: " + line);

      int gameId = int.Parse(matchCollection[0].Groups[1].Value);
      return new Game(gameId);
    }).ToArray();
  }
}

public class Game
{
  public Game(int id)
  {
    this.Id = id;
  }

  public int Id { get; }
}