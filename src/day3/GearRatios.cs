
namespace aoc2023.day3;

public class GearRatios
{
  private const int STAR_CHAR_CODE = 42;
  private const int DOT_CHAR_CODE = 46;
  private const int ZERO_CHAR_CODE = 48;
  private const int NINE_CHAR_CODE = 57;

  public int SumEngineParts(string[] inputLines)
  {
    int sum = 0;

    for (int y = 0; y < inputLines.Length; y++)
    {
      string line = inputLines[y];
      string readingNumber = "";
      bool toBeIncluded = false;
      for (int x = 0; x < line.Length; x++)
      {
        char character = line[x];
        if (IsAnInteger(character))
        {
          readingNumber += character;
          toBeIncluded = toBeIncluded || HasAdjacentSymbol(inputLines, x, y);
          continue;
        }

        if (toBeIncluded)
        {
          sum += int.Parse(readingNumber);
        }

        toBeIncluded = false;
        readingNumber = "";
      }

      if (toBeIncluded)
      {
        sum += int.Parse(readingNumber);
      }
    }

    return sum;
  }

  public int SumGearRatios(string[] input)
  {
    throw new NotImplementedException();
  }

  private bool HasAdjacentSymbol(string[] sourceMatrix, int x, int y)
  {
    List<(int, int)> adjacentCoordinates = [
      (x-1, y-1), (x, y-1), (x+1, y-1),
      (x-1, y), (x+1, y),
      (x-1, y+1), (x, y+1), (x+1, y+1),
    ];

    return adjacentCoordinates
      .Where(coordinate => IsValidCoordinate(coordinate, sourceMatrix))
      .Where(coordinate =>
      {
        var (cx, cy) = coordinate;
        char c = sourceMatrix[cy][cx];
        return !IsAnInteger(c) && (c != DOT_CHAR_CODE);
      })
      .Any();
  }

  private bool IsValidCoordinate((int, int) coordinate, string[] sourceMatrix)
  {
    var (x, y) = coordinate;
    return x >= 0 && y >= 0 &&
      y < sourceMatrix.Length &&
      x < sourceMatrix[0].Length;

  }

  private bool IsAnInteger(char c)
  {
    return c >= ZERO_CHAR_CODE && c <= NINE_CHAR_CODE;
  }

}