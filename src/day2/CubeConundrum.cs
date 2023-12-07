namespace aoc2023.day2;

public class CubeConundrum
{
  public int SumOfPossibileGame(string[] inputLines)
  {
    var MaxPossibleRedCubesCount = 12;
    var MaxPossibleGreenCubesCount = 13;
    var MaxPossibleBlueCubesCount = 14;

    var games = ParseGames(inputLines);
    return games.Where(game =>
    {
      return
        game.MaxCountInSet(CubeColor.RED) <= MaxPossibleRedCubesCount &&
        game.MaxCountInSet(CubeColor.GREEN) <= MaxPossibleGreenCubesCount &&
        game.MaxCountInSet(CubeColor.BLUE) <= MaxPossibleBlueCubesCount;
    })
    .Sum(game => game.Id);
  }

  public long SumOfPowerOfMinimumNeededCubes(string[] inputLines)
  {
    var games = ParseGames(inputLines);
    return games.Sum(game => game.PowerOfMinimumNeededCubes());
  }

  internal Game[] ParseGames(string[] inputLines)
  {
    return inputLines.Select(GameParser.ParseGame).ToArray();
  }
}
