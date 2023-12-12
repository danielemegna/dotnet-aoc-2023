namespace aoc2023.day3;

using Xunit;

public class EngineSchematicParserTest
{

  public class ParseProvidedExample()
  {
    [Fact]
    public void AndGetEngineParts()
    {
      var actual = EngineSchematicParser.Parse(GearRatiosTest.PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal<int[]>([467, 35, 633, 617, 592, 755, 664, 598], actual.EngineParts);
    }

    [Fact(Skip = "WIP")]
    public void AndGetGearRatios()
    {
      var actual = EngineSchematicParser.Parse(GearRatiosTest.PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal<int[]>([(467 * 35), (755 * 598)], actual.GearRatios);
    }
  }

  public class ParseAnotherExampleWithPartsAtTheEdgeButWithoutGears()
  {
    private readonly string[] inputLines = [
      ".....739.....",
      "11....@..92..",
      ".............",
      "......83.....",
      "44...........",
      ".#.........32",
      "...133....*..",
      ".............",
      "....&........",
      ".....82......",
    ];

    [Fact]
    public void AndGetEngineParts()
    {
      var actual = EngineSchematicParser.Parse(inputLines);
      Assert.Equal<int[]>([739, 44, 32, 82], actual.EngineParts);
    }

    [Fact]
    public void AndGetGearRatios()
    {
      var actual = EngineSchematicParser.Parse(inputLines);
      Assert.Equal<int[]>([], actual.GearRatios);
    }
  }
}
