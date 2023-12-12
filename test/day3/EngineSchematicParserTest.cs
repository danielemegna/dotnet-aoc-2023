namespace aoc2023.day3;

using Xunit;

public class EngineSchematicParserTest
{

  public class ParseProvidedExample()
  {
    [Fact]
    public void GetEngineParts()
    {
      var input = new string[] {
          "467..114..",
          "...*......",
          "..35..633.",
          "......#...",
          "617*......",
          ".....+.58.",
          "..592.....",
          "......755.",
          "...$.*....",
          ".664.598..",
        };

      var actual = EngineSchematicParser.Parse(input);

      Assert.Equal<int[]>([467, 35, 633, 617, 592, 755, 664, 598], actual.EngineParts);
    }
  }

  public class ParseAnotherExample() {
    
    [Fact]
    public void GetEngineParts()
    {
      var input = new string[] {
        ".....739.....",
        "......@......",
        ".............",
        ".............",
        "44...........",
        ".#.........32",
        "..........*..",
        ".............",
        "....&........",
        ".....82......",
      };

      var actual = EngineSchematicParser.Parse(input);

      Assert.Equal<int[]>([739, 44, 32, 82], actual.EngineParts);
    }
  }
}
