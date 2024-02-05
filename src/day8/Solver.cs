namespace aoc2023.day8;

public class Solver
{
  public long StepsToReachDestination(string[] inputLines)
  {
    var (moves, networkMap) = DocumentsParser.Parse(inputLines);
    var camel = new Camel("AAA", networkMap);
    return camel.WalkedStepsToReachDestinationWith(moves);
  }

  public long StepsToReachDestinationWithEveryGhost(string[] inputLines)
  {
    var (moves, networkMap) = DocumentsParser.Parse(inputLines);

    var startingNodeMinimumValue = DocumentsParser.NodeNameToInt("AAA");
    var startingNodeMaximumValue = DocumentsParser.NodeNameToInt("ZZA");

    var camels = networkMap
      .Select(networkNode => networkNode.Key)
      .Where(nodeIntValue => nodeIntValue < startingNodeMaximumValue)
      .Select(startingNodeValue => new Camel(startingNodeValue, networkMap))
      .ToArray();

    var movesIndex = 0;
    while (true)
    {  
      if (movesIndex == moves.Length)
        movesIndex = 0;

      var moveToPerform = moves[movesIndex];
      //camels.AsParallel().ForAll(c => c.Move(moveToPerform));
      foreach (var c in camels) { c.Move(moveToPerform); }
      movesIndex++;

      if (camels.All(c => c.IsDestinationReached()))
        break;
    };

    return camels.First().WalkedSteps;
  }
}