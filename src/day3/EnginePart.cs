namespace aoc2023.day3;

using Coordinate = Tuple<int, int>;

public record EnginePart(char Symbol, HashSet<int> AdjacentNumbers)
{
  public const int ZERO_CHAR_CODE = 48;
  public const int NINE_CHAR_CODE = 57;
  public const int STAR_CHAR_CODE = 42;
  public const int DOT_CHAR_CODE = 46;

  public bool IsAGear() => Symbol == STAR_CHAR_CODE && AdjacentNumbers.Count == 2;
  public int GearRatio() => AdjacentNumbers.Aggregate((a, b) => a * b);

  public static bool IsAnInteger(char c) => c >= ZERO_CHAR_CODE && c <= NINE_CHAR_CODE;

  public static EnginePart From(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int x, int y) = partCoordinate;
    char symbol = inputMatrix[y][x];

    int[] numbersOnTheRight = NumbersOnTheRight(inputMatrix, partCoordinate);
    int[] numbersOnTheLeft = NumbersOnTheLeft(inputMatrix, partCoordinate);
    int[] numbersAbove = NumbersAbove(inputMatrix, partCoordinate);
    int[] numbersBelow = NumbersBelow(inputMatrix, partCoordinate);

    return new EnginePart(symbol, [.. numbersOnTheRight, .. numbersOnTheLeft, .. numbersAbove, .. numbersBelow]);
  }

  private static int[] NumbersOnTheLeft(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int x, int y) = partCoordinate;
    if (x == 0)
      return [];

    int leftX = x - 1;
    return FindNumbersWith(
      inputMatrix: inputMatrix,
      yCursor: y,
      startingX: leftX,
      endX: leftX,
      maxPossibileXValue: leftX
    );
  }

  private static int[] NumbersOnTheRight(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int x, int y) = partCoordinate;
    int maxPossibileXValue = inputMatrix[y].Length - 1;
    if (x == maxPossibileXValue)
      return [];

    int rightX = x + 1;
    return FindNumbersWith(
      inputMatrix: inputMatrix,
      yCursor: y,
      startingX: rightX,
      endX: rightX,
      maxPossibileXValue: maxPossibileXValue
    );
  }

  private static int[] NumbersAbove(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int x, int y) = partCoordinate;
    if (y == 0)
      return [];

    int aboveRowY = y - 1;
    int maxPossibileXValue = inputMatrix[aboveRowY].Length - 1;
    return FindNumbersWith(
      inputMatrix: inputMatrix,
      yCursor: aboveRowY,
      startingX: Math.Max(0, x - 1),
      endX: Math.Min(x + 1, maxPossibileXValue),
      maxPossibileXValue: maxPossibileXValue
    );
  }

  private static int[] NumbersBelow(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int x, int y) = partCoordinate;
    if (y == (inputMatrix.Length - 1))
      return [];

    int belowRowY = y + 1;
    int maxPossibileXValue = inputMatrix[belowRowY].Length - 1;
    return FindNumbersWith(
      inputMatrix: inputMatrix,
      yCursor: belowRowY,
      startingX: Math.Max(0, x - 1),
      endX: Math.Min(x + 1, maxPossibileXValue),
      maxPossibileXValue: maxPossibileXValue
    );
  }

  private static int[] FindNumbersWith(string[] inputMatrix, int yCursor, int startingX, int endX, int maxPossibileXValue)
  {
    // TODO here we could add a cache

    List<int> result = [];
    int xCursor = startingX;

    while (xCursor > 0)
    {
      char currentChar = inputMatrix[yCursor][xCursor];
      if (!IsAnInteger(currentChar))
        break;
      xCursor--;
    }

    while (xCursor <= endX)
    {
      string number = "";
      while (xCursor <= maxPossibileXValue)
      {
        char currentChar = inputMatrix[yCursor][xCursor];
        if (!IsAnInteger(currentChar))
          break;

        number += currentChar;
        xCursor++;
      }

      if (number != "")
        result.Add(int.Parse(number));
      xCursor++;
    }

    return result.ToArray();
  }

  public virtual bool Equals(EnginePart? other)
  {
    if ((object)this == other) return true;
    if (other is null) return false;
    if (EqualityContract != other.EqualityContract) return false;

    return
      Symbol.Equals(other.Symbol) &&
      AdjacentNumbers.SetEquals(other.AdjacentNumbers);
  }

}
