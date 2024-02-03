namespace aoc2023.day8;

public class Solver
{
  public int StepsToReachDestination(string[] inputLines)
  {
    var parser = new DocumentsParser();
    var documents = parser.Parse(inputLines);
    var moves = documents.Moves;
    var network = documents.Network;

    var currentPosition = DocumentsParser.STARTING_NODE_INT_VALUE;
    var steps = 0;
    do
    {
      var move = moves[steps % moves.Length];
      var currentPositionNode = network[currentPosition];
      currentPosition = move switch
      {
        Move.LEFT => currentPositionNode.Item1,
        Move.RIGHT => currentPositionNode.Item2,
        _ => throw new SystemException("Something strange here ..")
      };

      steps++;
    } while (currentPosition != DocumentsParser.DESTINATION_NODE_INT_VALUE);

    return steps;
  }
}