
namespace aoc2023.day3;

public class EngineSchematicParser
{

  public static EngineSchematic Parse(string[] inputLines)
  {
    List<int> engineParts = []; // change this to List<EnginePart>
    List<int> gearRatios = []; // change this to List<EnginePart>

    for (int y = 0; y < inputLines.Length; y++)
    {
      for (int x = 0; x < inputLines[y].Length; x++)
      {
        char currentChar = inputLines[y][x];
        if (EnginePart.IsAnInteger(currentChar) || currentChar == EnginePart.DOT_CHAR_CODE)
          continue;

        EnginePart enginePart = EnginePart.From(inputLines, new(x, y));
        engineParts.AddRange(enginePart.AdjacentNumbers);

        if(enginePart.IsAGear())
          gearRatios.Add(enginePart.GearRatio());
      }
    }

    return new EngineSchematic(engineParts.ToArray(), gearRatios.ToArray());
  }
}
