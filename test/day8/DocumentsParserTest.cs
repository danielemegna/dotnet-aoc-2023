namespace aoc2023.day8;

using Xunit;

public class DocumentsParserTest
{
  private readonly DocumentsParser parser = new();

  [Fact]
  public void ParseFirstProvidedExample()
  {
    Documents actual = parser.Parse(SolverTest.FIRST_PROVIDED_EXAMPLE_INPUT_LINES);

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
    Assert.Equal(expectedNetwork, actual.Network);
  }

  [Fact]
  public void ParseSecondProvidedExample()
  {
    Documents actual = parser.Parse(SolverTest.SECOND_PROVIDED_EXAMPLE_INPUT_LINES);

    Move[] expectedMoves = [Move.LEFT, Move.LEFT, Move.RIGHT];
    Dictionary<int, (int, int)> expectedNetwork = new() {
        { 0,      (10101,  10101) },
        { 10101,  (0,      252525) },
        { 252525, (252525, 252525) },
      };
    Assert.Equal(expectedMoves, actual.Moves);
    Assert.Equal(expectedNetwork, actual.Network);
  }

  [Fact]
  public void ParseSomeOther()
  {
    string[] input = [
      "L",
      "",
      "AAA = (AAB, AZZ)",
      "BAA = (BAB, BZZ)",
      "CAA = (CAB, CZZ)",
      "ZAA = (ZAB, ZZZ)",
  ];
    Documents actual = parser.Parse(input);

    Move[] expectedMoves = [Move.LEFT];
    Dictionary<int, (int, int)> expectedNetwork = new() {
        { 0,      (1,      2525) },
        { 10000,  (10001,  12525) },
        { 20000,  (20001,  22525) },
        { 250000, (250001, 252525) },
      };
    Assert.Equal(expectedMoves, actual.Moves);
    Assert.Equal(expectedNetwork, actual.Network);
  }


}
