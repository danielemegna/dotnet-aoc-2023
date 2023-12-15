
namespace aoc2023.day3;

public class GearRatios
{
  public int SumEngineParts(string[] inputLines)
  {
    var engineParts = ParseEngineSchematic(inputLines);
    return engineParts
      .Select(e => e.AdjacentNumbers.Sum())
      .Sum();
  }

  public int SumGearRatios(string[] inputLines)
  {
    var engineParts = ParseEngineSchematic(inputLines);
    return engineParts
      .Where(e => e.IsAGear())
      .Select(e => e.GearRatio())
      .Sum();
  }

  internal EnginePart[] ParseEngineSchematic(string[] inputLines)
  {
    List<EnginePart> result = [];
    for (int y = 0; y < inputLines.Length; y++)
    {
      for (int x = 0; x < inputLines[y].Length; x++)
      {
        char currentChar = inputLines[y][x];
        if (EnginePart.IsAnInteger(currentChar) || currentChar == EnginePart.DOT_CHAR_CODE)
          continue;

        EnginePart enginePart = EnginePart.From(inputLines, new(x, y));
        result.Add(enginePart);
      }
    }
    return result.ToArray();
  }

}
