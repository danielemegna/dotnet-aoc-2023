namespace aoc2023.day3;

using Xunit;

public class EngineSchematicParserTest
{
  public class GetEngineParts()
  {
    [Fact]
    public void OfProvidedExample()
    {
      var actual = EngineSchematicParser.Parse(GearRatiosTest.PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal<int[]>([467, 35, 633, 617, 592, 664, 755, 598], actual.EngineParts);
    }

    [Fact]
    public void OfAnotherExampleWithPartsAtTheEdge()
    {
      string[] inputLines = [
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
      var actual = EngineSchematicParser.Parse(inputLines);
      Assert.Equal<int[]>([739, 44, 32, 82], actual.EngineParts);
    }

  }

  public class GetGearRatios()
  {
    [Fact]
    public void OfProvidedExample()
    {
      var actual = EngineSchematicParser.Parse(GearRatiosTest.PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal<int[]>([(467 * 35), (755 * 598)], actual.GearRatios);
    }

    [Fact]
    public void OfAnotherExampleWithoutAnyGear()
    {
      string[] inputLines = [
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
      var actual = EngineSchematicParser.Parse(inputLines);
      Assert.Equal<int[]>([], actual.GearRatios);
    }
  }
}
