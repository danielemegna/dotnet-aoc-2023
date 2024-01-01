namespace aoc2023.day22;

public class Solver
{
  public int CountSafeToDisintegrateBricks(string[] inputLines)
  {
    var parsedBricks = new BrickParser().ParseBricks(inputLines);
    var bricksSnapshot = new BricksSnapshot(parsedBricks);
    bricksSnapshot.CompleteFall();
    return bricksSnapshot.CountSafeToDisintegrateBricks();
  }
}