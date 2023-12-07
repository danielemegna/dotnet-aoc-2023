using System.Text.RegularExpressions;

namespace aoc2023.day2;

class GameParser()
{
  public static Game ParseGame(string gameInputLine)
  {
    Regex regex = new Regex(@"^Game (\d+): (.+$)");
    MatchCollection matchCollection = regex.Matches(gameInputLine);

    if (matchCollection.Count < 1 || matchCollection[0].Groups.Count < (1 + 2))
      throw new FormatException("Cannot parse game line: " + gameInputLine);

    int gameId = int.Parse(matchCollection[0].Groups[1].Value);
    string setsString = matchCollection[0].Groups[2].Value;

    return BuildGameWith(gameId, setsString);
  }

  private static Game BuildGameWith(int gameId, string setsString)
  {
    string[] setStringsArray = setsString.Split(";", StringSplitOptions.TrimEntries);

    var game = new Game(gameId);
    foreach (var singleSetString in setStringsArray)
    {
      var gameSet = ParseSet(singleSetString);
      game.AddSet(gameSet);
    }

    return game;
  }

  private static Game.Set ParseSet(string setString)
  {
    var gameSet = new Game.Set();

    string[] singleSetParts = setString.Split(",", StringSplitOptions.TrimEntries);
    foreach (var cubeData in singleSetParts)
    {
      string[] parts = cubeData.Split(" ", StringSplitOptions.TrimEntries);
      int quantity = int.Parse(parts[0]);
      CubeColor cubeColor = (CubeColor)Enum.Parse(typeof(CubeColor), parts[1].ToUpper());
      gameSet.AddCubeCount(cubeColor, quantity);
    }

    return gameSet;
  }


}