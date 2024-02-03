namespace aoc2023.day8;

public class Camel
{
  private readonly Dictionary<int, (int, int)> networkMap;

  public int WalkedSteps { get; private set; }
  private int currentPositionNodeValue;

  public Camel(int startingNodeValue, Dictionary<int, (int, int)> networkMap)
  {
    this.networkMap = networkMap;
    this.currentPositionNodeValue = startingNodeValue;
    this.WalkedSteps = 0;
  }

  public void Move(Move move)
  {
    var currentPositionNode = networkMap[currentPositionNodeValue];
    var newPosition = move switch
    {
      day8.Move.LEFT => currentPositionNode.Item1,
      day8.Move.RIGHT => currentPositionNode.Item2,
      _ => throw new SystemException("Something very strange here ..")
    };

    currentPositionNodeValue = newPosition;
    WalkedSteps++;
  }

  public bool IsCurrentPositionFinal()
  {
    return currentPositionNodeValue == DocumentsParser.DESTINATION_NODE_INT_VALUE;
  }
}