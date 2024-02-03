namespace aoc2023.day8;

public class Solver
{
  public int StepsToReachDestination(string[] inputLines)
  {
    var (moves, networkMap) = DocumentsParser.Parse(inputLines);
    var camel = new Camel("AAA", networkMap);

    var movesIndex = 0;
    do
    {
      if(movesIndex == moves.Length)
        movesIndex = 0;

      camel.Move(moves[movesIndex]);
      movesIndex++;
    } while (!camel.IsDestinationReached());

    return camel.WalkedSteps;
  }

}