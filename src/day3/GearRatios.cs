
namespace aoc2023.day3;

public class GearRatios
{
  public int SumEngineParts(string[] inputLines)
  {
    var engineSchematic = EngineSchematicParser.Parse(inputLines);
    return engineSchematic.EngineParts.Sum();
  }

  public int SumGearRatios(string[] inputLines)
  {
    var engineSchematic = EngineSchematicParser.Parse(inputLines);
    return engineSchematic.GearRatios.Sum();
  }

}
