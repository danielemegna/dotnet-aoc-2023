namespace aoc2023.day8;

public class Solver
{

  public int StepsToReachDestination(string[] inputLines)
  {
    var (moves, network) = DocumentsParser.Parse(inputLines);
    var camel = new Camel(DocumentsParser.STARTING_NODE_INT_VALUE, network);

    do
    {
      var move = moves[camel.WalkedSteps % moves.Length];
      camel.Move(move);
    } while (!camel.IsCurrentPositionFinal());

    return camel.WalkedSteps;
  }
}