namespace aoc2023.day3;

using Coordinate = Tuple<int, int>;

public class EnginePart(char symbol, int[] adjacentNumbers)
{
  private const int ZERO_CHAR_CODE = 48;
  private const int NINE_CHAR_CODE = 57;

  public char Symbol { get; } = symbol;
  public int[] AdjacentNumbers { get; } = adjacentNumbers;

  public static EnginePart From(string[] inputMatrix, Coordinate coordinate)
  {
    (int x, int y) = coordinate;
    char symbol = inputMatrix[y][x];

    int[] numbersOnTheRight = NumbersOnTheRight(inputMatrix, coordinate);
    int[] numbersOnTheLeft = NumbersOnTheLeft(inputMatrix, coordinate);
    int[] numbersAbove = NumbersAbove(inputMatrix, coordinate);
    int[] numbersBelow = NumbersBelow(inputMatrix, coordinate);

    return new EnginePart(symbol, [.. numbersOnTheRight, .. numbersOnTheLeft, .. numbersAbove, .. numbersBelow]);
  }

  private static int[] NumbersOnTheRight(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int partX, int partY) = partCoordinate;
    int maxPossibileXValue = inputMatrix[partY].Length - 1;
    int rightX = Math.Min(partX + 1, maxPossibileXValue);
    return FindNumbersWith(inputMatrix, partY, rightX, rightX, maxPossibileXValue);
  }

  private static int[] NumbersOnTheLeft(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int partX, int partY) = partCoordinate;
    int leftX = Math.Max(0, partX - 1);
    return FindNumbersWith(inputMatrix, partY, leftX, leftX, partX);
  }

  private static int[] NumbersAbove(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int partX, int partY) = partCoordinate;
    if (partY == 0)
      return [];

    int rowY = partY - 1;
    return FindNumbersInRow(inputMatrix, rowY, partX);
  }

  private static int[] NumbersBelow(string[] inputMatrix, Coordinate partCoordinate)
  {
    (int partX, int partY) = partCoordinate;
    if (partY == (inputMatrix.Length - 1))
      return [];

    int rowY = partY + 1;
    return FindNumbersInRow(inputMatrix, rowY, partX);
  }

  private static int[] FindNumbersInRow(string[] inputMatrix, int rowY, int partX)
  {
    int maxPossibileXValue = inputMatrix[rowY].Length - 1;
    int startingX = Math.Max(0, partX - 1);
    int endX = Math.Min(partX + 1, maxPossibileXValue);
    return FindNumbersWith(inputMatrix, rowY, startingX, endX, maxPossibileXValue);
  }

  private static int[] FindNumbersWith(string[] inputMatrix, int yCursor, int startingX, int endX, int maxPossibileXValue)
  {
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


  private static bool IsAnInteger(char c)
  {
    return c >= ZERO_CHAR_CODE && c <= NINE_CHAR_CODE;
  }
}