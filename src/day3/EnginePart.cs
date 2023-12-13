namespace aoc2023.day3;

using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Coordinate = Tuple<int, int>;

public class EnginePart(char symbol, int[] adjacentNumbers)
{
  private const int STAR_CHAR_CODE = 42;
  private const int DOT_CHAR_CODE = 46;
  private const int ZERO_CHAR_CODE = 48;
  private const int NINE_CHAR_CODE = 57;

  public char Symbol { get; } = symbol;
  public int[] AdjacentNumbers { get; } = adjacentNumbers;

  public static EnginePart From(string[] inputMatrix, Coordinate coordinate)
  {
    (int x, int y) = coordinate;
    char symbol = inputMatrix[y][x];

    int[] numbersOnTheRight = NumbersOnTheRight(inputMatrix, coordinate);

    return new EnginePart(symbol, numbersOnTheRight);
  }

  private static int[] NumbersOnTheRight(string[] inputMatrix, Coordinate c)
  {
    int startingX = c.Item1 + 1;
    int y = c.Item2;
    int rowTotalLenght = inputMatrix[y].Length;

    string number = "";
    for (int x = startingX; x < rowTotalLenght; x++)
    {
      char currentChar = inputMatrix[y][x];
      if (!IsAnInteger(currentChar))
        break;

      number += currentChar;
    }

    if (number == "")
      return [];

    return [int.Parse(number)];
  }

  private static bool IsAnInteger(char c)
  {
    return c >= ZERO_CHAR_CODE && c <= NINE_CHAR_CODE;
  }
}