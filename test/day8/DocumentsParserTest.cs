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

  [Fact]
  public void NodeNameToInt()
  {
    Assert.Equal(0, DocumentsParser.NodeNameToInt("AAA"));
    Assert.Equal(1, DocumentsParser.NodeNameToInt("AAB"));
    Assert.Equal(2525, DocumentsParser.NodeNameToInt("AZZ"));

    Assert.Equal(10000, DocumentsParser.NodeNameToInt("BAA"));
    Assert.Equal(10001, DocumentsParser.NodeNameToInt("BAB"));
    Assert.Equal(12525, DocumentsParser.NodeNameToInt("BZZ"));

    Assert.Equal(20000, DocumentsParser.NodeNameToInt("CAA"));
    Assert.Equal(20001, DocumentsParser.NodeNameToInt("CAB"));
    Assert.Equal(22525, DocumentsParser.NodeNameToInt("CZZ"));

    Assert.Equal(250000, DocumentsParser.NodeNameToInt("ZAA"));
    Assert.Equal(250001, DocumentsParser.NodeNameToInt("ZAB"));
    Assert.Equal(252525, DocumentsParser.NodeNameToInt("ZZZ"));
  }


}
