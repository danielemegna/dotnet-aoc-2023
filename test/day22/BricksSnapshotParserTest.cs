namespace aoc2023.day22;

using Xunit;

public class BricksSnapshotParserTest
{
  private readonly BricksSnapshotParser parser = new();

  public class ParseTheProvidedExample : BricksSnapshotParserTest
  {

    [Fact]
    public void ParseBricksList()
    {
      var bricks = parser.ParseBricks(SolverTest.PROVIDED_EXAMPLE_INPUT_LINES);

      HashSet<Brick> expected = [
        new Brick(new(1,0,1), new(1,2,1)), new Brick(new(0,0,2), new(2,0,2)),
        new Brick(new(0,2,3), new(2,2,3)), new Brick(new(0,0,4), new(0,2,4)),
        new Brick(new(2,0,5), new(2,2,5)), new Brick(new(0,1,6), new(2,1,6)),
        new Brick(new(1,1,8), new(1,1,9)),
      ];
      Assert.Equivalent(expected, bricks);
    }

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