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
      .Select(startingNodeValue => new Camel(startingNodeValue, networkMap));

    return camels
      .Select(camel => camel.WalkedStepsToReachDestinationWith(moves))
      .Aggregate(LeastCommonMultiple);
  }

  private static long LeastCommonMultiple(long a, long b) => a * b / GreatestCommonDivisor(a, b);

  private static long GreatestCommonDivisor(long a, long b)
  {
    if (b == 0) return a;
    return GreatestCommonDivisor(b, a % b);
  }
}