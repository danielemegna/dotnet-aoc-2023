namespace aoc2023.day22;

using Xunit;

public class BricksSnapshotParserTest
{
  private readonly BricksSnapshotParser parser = new();

  public class ParseTheProvidedExample : BricksSnapshotParserTest
  {
    [Fact]
    public void GetBrickAtEmptyCoordinate()
    {
      BricksSnapshot snapshot = parser.Parse(SolverTest.PROVIDED_EXAMPLE_INPUT_LINES);
      Coordinate coordinate = new(0, 0, 1);

      Brick actual = snapshot.BrickAt(coordinate);

      Assert.IsType<NullBrick>(actual);
    }

    [Fact(Skip = "WIP")]
    public void GetBrickAtCoordinate()
    {
      BricksSnapshot snapshot = parser.Parse(SolverTest.PROVIDED_EXAMPLE_INPUT_LINES);
      Coordinate coordinate = new(1, 0, 1);

      Brick actual = snapshot.BrickAt(coordinate);

      Brick expected = new(new(1, 0, 1), new(1, 2, 1));
      Assert.IsType<Brick>(actual);
      Assert.Equal(expected, actual);
    }

    // TODO: test parser.GetBricksFrom(..) as internal ?
    // TODO: assert two coordinates of same brick returns same object reference
    // TODO: test snapshot.BrickAt(new(x,x,0)) -> throws an exception ?
    // TODO: should we extract BricksSnapshotTest class ?

  }
}