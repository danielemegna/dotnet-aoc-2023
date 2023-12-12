namespace aoc2023.day3;

using Xunit;

public class EngineSchematicParserTest
{

  public class ParseProvidedExample()
  {
    [Fact]
    public void GetEngineParts()
    {
      var actual = EngineSchematicParser.Parse(GearRatiosTest.PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal<int[]>([467, 35, 633, 617, 592, 755, 664, 598], actual.EngineParts);
    }
  }

  public class ParseAnotherExample() {
    
    [Fact]
    public void GetEngineParts()
    {
      string[] input = [
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

      var actual = EngineSchematicParser.Parse(input);

      Assert.Equal<int[]>([739, 44, 32, 82], actual.EngineParts);
    }
  }
}
