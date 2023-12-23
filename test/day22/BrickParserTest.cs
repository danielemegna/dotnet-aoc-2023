namespace aoc2023.day22;

using Xunit;

public class BrickParserTest
{

  [Fact]
  public void ParseTheProvidedExample()
  {
    var parser = new BrickParser();

    var bricks = parser.ParseBricks(SolverTest.PROVIDED_EXAMPLE_INPUT_LINES);

    HashSet<Brick> expected = [
      new Brick(new(1,0,1), new(1,2,1)), new Brick(new(0,0,2), new(2,0,2)),
      new Brick(new(0,2,3), new(2,2,3)), new Brick(new(0,0,4), new(0,2,4)),
      new Brick(new(2,0,5), new(2,2,5)), new Brick(new(0,1,6), new(2,1,6)),
      new Brick(new(1,1,8), new(1,1,9)),
    ];
    Assert.Equivalent(expected, bricks);
  }
}