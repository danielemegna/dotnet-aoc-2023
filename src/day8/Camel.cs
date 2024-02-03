namespace aoc2023.day8;

public class Camel
{
  private Dictionary<int, (int, int)> networkMap;
  private int currentPosition;
  public int WalkedSteps { get; private set; }

  public Camel(int startingPosition, Dictionary<int, (int, int)> networkMap)
  {
    this.currentPosition = startingPosition;
    this.networkMap = networkMap;
    this.WalkedSteps = 0;
  }

  public void Move(Move move)
  {
    var currentPositionNode = networkMap[currentPosition];
    var newPosition = move switch
    {
      day8.Move.LEFT => currentPositionNode.Item1,
      day8.Move.RIGHT => currentPositionNode.Item2,
      _ => throw new SystemException("Something very strange here ..")
    };

    currentPosition = newPosition;
    WalkedSteps++;
  }

  public bool IsCurrentPositionFinal()
  {
    return currentPosition == DocumentsParser.DESTINATION_NODE_INT_VALUE;
  }
}