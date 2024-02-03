namespace aoc2023.day8;

public class DocumentsParser
{
  public const int STARTING_NODE_INT_VALUE = 0;
  public const int DESTINATION_NODE_INT_VALUE = 252525;

  public static Documents Parse(string[] inputLines)
  {
    var movesString = inputLines[0];
    Move[] moves = MovesFromString(movesString);

    var networkLines = inputLines.Skip(2);
    var network = networkLines
      .Select(NetworkElementFrom)
      .ToDictionary();

    return new Documents(moves, network);
  }

  public static int NodeNameToInt(string nodeName)
  {
    string numberAsString = nodeName
      .ToCharArray()
      .Select(c => c - 65)
      .Select(i => i.ToString().PadLeft(2, '0'))
      .Aggregate((a, b) => a + b);

    return int.Parse(numberAsString);

  }

  private static KeyValuePair<int, (int, int)> NetworkElementFrom(string line)
  {
    var cleanedLine = line.Replace(",", "").Replace("=", "").Replace("(", "").Replace(")", "");
    var lineParts = cleanedLine.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

    var startingPoint = lineParts[0];
    var leftConnection = lineParts[1];
    var rightConnection = lineParts[2];
    return new KeyValuePair<int, (int, int)>(
      NodeNameToInt(startingPoint),
      (
        NodeNameToInt(leftConnection),
        NodeNameToInt(rightConnection)
      )
    );
  }

  private static Move[] MovesFromString(string value)
  {
    return value
      .ToCharArray()
      .Select(MoveFromChar)
      .ToArray();
  }

  private static Move MoveFromChar(char c)
  {
    return c switch
    {
      'L' => Move.LEFT,
      'R' => Move.RIGHT,
      _ => throw new SystemException($"Cannot parse move from char [{c}]")
    };
  }

}