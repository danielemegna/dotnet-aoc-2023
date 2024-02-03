namespace aoc2023.day8;

public class DocumentsParser {

  public Documents Parse(string[] inputLines)
  {
    var movesString = inputLines[0];
    Move[] moves = MovesFromString(movesString);

    var networkLines = inputLines.Skip(2);
    var network = networkLines
      .Select(NetworkElementFrom)
      .ToDictionary();

    return new Documents(moves, network);
  }

  private static KeyValuePair<int, (int, int)> NetworkElementFrom(string line)
  {
    var cleanedLine = line.Replace(",", "").Replace("=", "").Replace("(", "").Replace(")", "");
    var lineParts = cleanedLine.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

    var startingPoint = lineParts[0];
    var leftConnection = lineParts[1];
    var rightConnection = lineParts[2];
    return new KeyValuePair<int, (int, int)>(
      startingPoint.GetHashCode(),
      (
        leftConnection.GetHashCode(),
        rightConnection.GetHashCode()
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