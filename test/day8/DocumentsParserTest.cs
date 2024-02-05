namespace aoc2023.day8;

using Xunit;

public class DocumentsParserTest
{

  [Fact]
  public void ParseFirstProvidedExample()
  {
    Documents actual = DocumentsParser.Parse(SolverTest.FIRST_PROVIDED_EXAMPLE_INPUT_LINES);

    Move[] expectedMoves = [Move.RIGHT, Move.LEFT];
    Dictionary<int, (int, int)> expectedNetwork = new() {
        { 0,      (10101,  20202) },
        { 10101,  (30303,  40404) },
        { 20202,  (252525, 60606) },
        { 30303,  (30303,  30303) },
        { 40404,  (40404,  40404) },
        { 60606,  (60606,  60606) },
        { 252525, (252525, 252525) },
      };
    Assert.Equal(expectedMoves, actual.Moves);
    Assert.Equal(expectedNetwork, actual.NetworkMap);
  }

  [Fact]
  public void ParseSecondProvidedExample()
  {
    Documents actual = DocumentsParser.Parse(SolverTest.SECOND_PROVIDED_EXAMPLE_INPUT_LINES);

    Move[] expectedMoves = [Move.LEFT, Move.LEFT, Move.RIGHT];
    Dictionary<int, (int, int)> expectedNetwork = new() {
        { 0,      (10101,  10101) },
        { 10101,  (0,      252525) },
        { 252525, (252525, 252525) },
      };
    Assert.Equal(expectedMoves, actual.Moves);
    Assert.Equal(expectedNetwork, actual.NetworkMap);
  }

  public class NodeNameToInt()
  {

    [Fact]
    public void EndingWithAGoesFromZeroTo2525()
    {
      Assert.Equal(0, DocumentsParser.NodeNameToInt("AAA"));
      Assert.Equal(1, DocumentsParser.NodeNameToInt("BAA"));
      Assert.Equal(100, DocumentsParser.NodeNameToInt("ABA"));
      Assert.Equal(101, DocumentsParser.NodeNameToInt("BBA"));
      Assert.Equal(2525, DocumentsParser.NodeNameToInt("ZZA"));
    }

    [Fact]
    public void EndingWithBGoesFrom10000To12525()
    {
      Assert.Equal(10000, DocumentsParser.NodeNameToInt("AAB"));
      Assert.Equal(10001, DocumentsParser.NodeNameToInt("BAB"));
      Assert.Equal(10100, DocumentsParser.NodeNameToInt("ABB"));
      Assert.Equal(12525, DocumentsParser.NodeNameToInt("ZZB"));
    }

    [Fact]
    public void EndingWithCGoesFrom20000To22525()
    {
      Assert.Equal(20000, DocumentsParser.NodeNameToInt("AAC"));
      Assert.Equal(20001, DocumentsParser.NodeNameToInt("BAC"));
      Assert.Equal(20100, DocumentsParser.NodeNameToInt("ABC"));
      Assert.Equal(22525, DocumentsParser.NodeNameToInt("ZZC"));
    }

    [Fact]
    public void EndingWithZGoesFrom25000To252525()
    {
      Assert.Equal(250000, DocumentsParser.NodeNameToInt("AAZ"));
      Assert.Equal(250001, DocumentsParser.NodeNameToInt("BAZ"));
      Assert.Equal(250100, DocumentsParser.NodeNameToInt("ABZ"));
      Assert.Equal(252525, DocumentsParser.NodeNameToInt("ZZZ"));
    }

  }


}
