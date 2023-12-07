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
      Regex regex = new Regex(@"^Game (\d): (.+$)");
      MatchCollection matchCollection = regex.Matches(line);

      if (matchCollection.Count < 1 || matchCollection[0].Groups.Count < (1 + 2))
        throw new FormatException("Cannot parse game line: " + line);

      int gameId = int.Parse(matchCollection[0].Groups[1].Value);
      string setsString = matchCollection[0].Groups[2].Value;

      var game = new Game(gameId);

      string[] setStringsArray = setsString.Split(";", StringSplitOptions.TrimEntries);
      foreach (var singleSetString in setStringsArray)
      {
        var gameSet = new Game.Set();
        string[] singleSetParts = singleSetString.Split(",", StringSplitOptions.TrimEntries);
        foreach (var cubeData in singleSetParts)
        {
          string[] parts = cubeData.Split(" ", StringSplitOptions.TrimEntries);
          int quantity = int.Parse(parts[0]);
          CubeColor cubeColor = (CubeColor)Enum.Parse(typeof(CubeColor), parts[1].ToUpper());
          gameSet.AddCubeCount(cubeColor, quantity);
        }
        game.AddSet(gameSet);
      }
      return game;
    }).ToArray();
  }
}

public enum CubeColor { BLUE, RED, GREEN };

public class Game(int id)
{
  public int Id { get; } = id;
  private int MaxBlueCubesCount = 0;
  private int MaxRedCubesCount = 0;
  private int MaxGreenCubesCount = 0;

  public void AddSet(Set gameSet)
  {
    if (MaxBlueCubesCount < gameSet.BlueCubesCount)
      MaxBlueCubesCount = gameSet.BlueCubesCount;
    if (MaxRedCubesCount < gameSet.RedCubesCount)
      MaxRedCubesCount = gameSet.RedCubesCount;
    if (MaxGreenCubesCount < gameSet.GreenCubesCount)
      MaxGreenCubesCount = gameSet.GreenCubesCount;
  }

  public int MaxCountInSet(CubeColor cubeColor)
  {
    return cubeColor switch
    {
      CubeColor.BLUE => MaxBlueCubesCount,
      CubeColor.RED => MaxRedCubesCount,
      CubeColor.GREEN => MaxGreenCubesCount,
    };
  }

  public class Set()
  {
    public int BlueCubesCount { get; private set; } = 0;
    public int RedCubesCount { get; private set; } = 0;
    public int GreenCubesCount { get; private set; } = 0;

    public void AddCubeCount(CubeColor color, int count)
    {
      switch (color)
      {
        case CubeColor.BLUE:
          BlueCubesCount = count;
          break;
        case CubeColor.RED:
          RedCubesCount = count;
          break;
        case CubeColor.GREEN:
          GreenCubesCount = count;
          break;
      }
    }
  }

}