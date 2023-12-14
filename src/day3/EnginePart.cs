namespace aoc2023.day3;

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
    int[] numbersOnTheLeft = NumbersOnTheLeft(inputMatrix, coordinate);
    int[] numbersAbove = NumbersAbove(inputMatrix, coordinate);

    return new EnginePart(symbol, [.. numbersOnTheRight, .. numbersOnTheLeft, .. numbersAbove]);
  }

  private static int[] NumbersOnTheRight(string[] inputMatrix, Coordinate coordinate)
  {
    int startingX = coordinate.Item1 + 1;
    int y = coordinate.Item2;
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

  private static int[] NumbersOnTheLeft(string[] inputMatrix, Coordinate coordinate)
  {
    int startingX = coordinate.Item1 - 1;
    int y = coordinate.Item2;

    string number = "";
    for (int x = startingX; x >= 0; x--)
    {
      char currentChar = inputMatrix[y][x];
      if (!IsAnInteger(currentChar))
        break;

      number = currentChar + number;
    }

    if (number == "")
      return [];

    return [int.Parse(number)];
  }

  private static int[] NumbersAbove(string[] inputMatrix, Coordinate coordinate)
  {
    if (coordinate.Item2 == 0)
      return [];

    List<int> result = [];
    int x = Math.Max(0, coordinate.Item1 - 1);
    int y = coordinate.Item2 - 1;
    int rowTotalLenght = inputMatrix[y].Length;

    while (x > 0)
    {
      char currentChar = inputMatrix[y][x];
      if (!IsAnInteger(currentChar))
        break;
      x--;
    }

    while (x <= coordinate.Item1 + 1)
    {
      string number = "";
      while (x < rowTotalLenght)
      {
        char currentChar = inputMatrix[y][x];
        if (!IsAnInteger(currentChar))
          break;

        number += currentChar;
        x++;
      }

      if (number != "")
        result.Add(int.Parse(number));
      x++;
    }

    return result.ToArray();
  }


  private static bool IsAnInteger(char c)
  {
    return c >= ZERO_CHAR_CODE && c <= NINE_CHAR_CODE;
  }
}