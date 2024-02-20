namespace aoc2023.day10;

using Xunit;

public class GardenMapTest
{

  public static readonly GardenMap simpleMap = new GardenMap([
    ['.','.','.','.','.'],
    ['.','S','-','7','.'],
    ['.','|','.','|','.'],
    ['.','L','-','J','.'],
    ['.','.','.','.','.']
  ]);

  public static readonly GardenMap complexMap = new GardenMap([
    ['.','.','F','7','.'],
    ['.','F','J','|','.'],
    ['S','J','.','L','7'],
    ['|','F','-','-','J'],
    ['L','J','.','.','.']
  ]);

  [Fact]
  public void BuildFromArrayOfStrings()
  {
    var actual = GardenMap.From(SolverTest.SIMPLE_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.Equal(simpleMap, actual);

    actual = GardenMap.From(SolverTest.COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.Equal(complexMap, actual);
  }

  [Fact]
  public void GetStartingPositionCoordinate()
  {
    var actual = simpleMap.StartingPosition();
    Assert.Equal(new Coordinate(1, 1), actual);

    actual = complexMap.StartingPosition();
    Assert.Equal(new Coordinate(0, 2), actual);
  }

  public class ConnectionsForCoordinates
  {
    [Fact]
    public void WestAndEastConnections()
    {
      var actual = complexMap.ConnectionsFor(new(2, 3));

      Coordinate leftExpected = new(1, 3);
      Coordinate rightExpected = new(3, 3);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void NortAndSouthConnections()
    {
      var actual = complexMap.ConnectionsFor(new(3, 1));

      Coordinate leftExpected = new(3, 0);
      Coordinate rightExpected = new(3, 2);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void SouthAndEastConnections()
    {
      var actual = complexMap.ConnectionsFor(new(1, 1));

      Coordinate leftExpected = new(1, 2);
      Coordinate rightExpected = new(2, 1);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void NordAndWestConnections()
    {
      var actual = complexMap.ConnectionsFor(new(2, 1));

      Coordinate leftExpected = new(1, 1);
      Coordinate rightExpected = new(2, 0);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void NordAndEastConnections()
    {
      var actual = complexMap.ConnectionsFor(new(3, 2));

      Coordinate leftExpected = new(3, 1);
      Coordinate rightExpected = new(4, 2);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void SouthAndWestConnectionsAtTheEdgeOfTheMap()
    {
      var actual = complexMap.ConnectionsFor(new(4, 2));

      Coordinate leftExpected = new(3, 2);
      Coordinate rightExpected = new(4, 3);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void SouthAndEastConnectionsAtTheEdgeOfTheMap()
    {
      var actual = complexMap.ConnectionsFor(new(0, 2));

      Coordinate leftExpected = new(0, 3);
      Coordinate rightExpected = new(1, 2);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void ConnectionsToStartingPointAreNull()
    {
      var actual = simpleMap.ConnectionsFor(new(1, 2));
      Assert.Equal((new Coordinate(1, 3), null), actual);

      actual = simpleMap.ConnectionsFor(new(2, 1));
      Assert.Equal((null, new Coordinate(3, 1)), actual);

      actual = complexMap.ConnectionsFor(new(1, 2));
      Assert.Equal((new Coordinate(1, 1), null), actual);

      actual = complexMap.ConnectionsFor(new(0, 3));
      Assert.Equal((new Coordinate(0, 4), null), actual);
    }

  }

  [Fact]
  public void Equality()
  {
    var first = simpleMap;
    var second = new GardenMap([
      ['.','.','.','.','.'],
      ['.','S','-','7','.'],
      ['.','|','.','|','.'],
      ['.','L','-','J','.'],
      ['.','.','.','.','.']
    ]);
    var third = complexMap;

    Assert.Equal(first, first);
    Assert.Same(first, first);

    Assert.Equal(first, second);
    Assert.Equal(second, first);
    Assert.False(first == second);
    Assert.NotSame(first, second);
    Assert.Equal(first.GetHashCode(), second.GetHashCode());

    Assert.NotEqual(first, third);
    Assert.NotEqual(third, second);
    Assert.NotEqual(first.GetHashCode(), third.GetHashCode());
  }

}
