namespace aoc2023.day8;

public class DocumentsParser
{
  public static Documents Parse(string[] inputLines)
  {
    var movesString = inputLines[0];
    Move[] moves = MovesFromString(movesString);

    var networkLines = inputLines.Skip(2);
    var networkMap = networkLines
      .Select(NetworkNodeFrom)
      .ToDictionary();

    return new Documents(moves, networkMap);
  }

  public static int NodeNameToInt(string nodeName)
  {
    string numberAsString = nodeName
      .ToCharArray()
      .Reverse()
      .Select(c => c - 65)
      .Select(i => i.ToString().PadLeft(2, '0'))
      .Aggregate((a, b) => a + b);

    return int.Parse(numberAsString);

  }

  private static KeyValuePair<int, (int, int)> NetworkNodeFrom(string line)
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