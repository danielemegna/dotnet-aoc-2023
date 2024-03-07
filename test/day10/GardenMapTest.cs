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
  public void GetMapValueAtCoordinate()
  {
    Assert.Equal('.', complexMap.MapValueAt(new(0, 0)));
    Assert.Equal('S', complexMap.MapValueAt(new(0, 2)));
    Assert.Equal('J', complexMap.MapValueAt(new(1, 2)));
    Assert.Equal('F', complexMap.MapValueAt(new(2, 0)));
    Assert.Equal('x', complexMap.MapValueAt(new(-1, -1)));
    Assert.Equal('x', complexMap.MapValueAt(new(99, 99)));
  }

  [Fact]
  public void GetLoopStartCoordinate()
  {
    Assert.Equal(new(1, 1), simpleMap.LoopStartCoordinate);
    Assert.Equal(new(0, 2), complexMap.LoopStartCoordinate);
    GardenMap largerMap = GardenMap.From(SolverTest.LARGER_COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.Equal(new(12, 4), largerMap.LoopStartCoordinate);
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
    public void SouthAndWestAtTheEdgeOfTheMap()
    {
      var actual = complexMap.ConnectionsFor(new(4, 2));

      Coordinate leftExpected = new(3, 2);
      Coordinate rightExpected = new(4, 3);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void NordAndSouthAtTheEdgeOfTheMap()
    {
      var actual = complexMap.ConnectionsFor(new(0, 3));

      Coordinate leftExpected = new(0, 2);
      Coordinate rightExpected = new(0, 4);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void StartCoordinateConnections()
    {
      var actual = simpleMap.ConnectionsFor(new(1, 1));
      Assert.Equal((new Coordinate(1, 2), new Coordinate(2, 1)), actual);
      actual = complexMap.ConnectionsFor(new(0, 2));
      Assert.Equal((new Coordinate(0, 3), new Coordinate(1, 2)), actual);
    }

    [Fact]
    public void NearStartCoordinate()
    {
      var actual = simpleMap.ConnectionsFor(new(1, 2));
      Assert.Equal((new Coordinate(1, 1), new Coordinate(1, 3)), actual);

      actual = simpleMap.ConnectionsFor(new(2, 1));
      Assert.Equal((new Coordinate(1, 1), new Coordinate(3, 1)), actual);

      actual = complexMap.ConnectionsFor(new(1, 2));
      Assert.Equal((new Coordinate(0, 2), new Coordinate(1, 1)), actual);

      actual = complexMap.ConnectionsFor(new(0, 3));
      Assert.Equal((new Coordinate(0, 2), new Coordinate(0, 4)), actual);
    }

    [Fact]
    public void GetOnlyCompatibleConnections()
    {
      var map = new GardenMap([
        ['.','|','.'],
        ['.','F','7'],
        ['.','L','S'],
      ]);

      var actual = map.ConnectionsFor(new(1, 1));

      Coordinate leftExpected = new(1, 2);
      Coordinate rightExpected = new(2, 1);
      Assert.Equal((leftExpected, rightExpected), actual);
    }
  }

  public class CheckCoordinateIsPartOfTheLoop()
  {

    [Fact]
    public void OutsideTheLoopIsNotPartOfTheLoop()
    {
      Assert.False(simpleMap.IsPartOfTheLoop(new(0, 0)));
      Assert.False(simpleMap.IsPartOfTheLoop(new(1, 0)));
      Assert.False(simpleMap.IsPartOfTheLoop(new(2, 0)));
      Assert.False(simpleMap.IsPartOfTheLoop(new(4, 2)));

      Assert.False(complexMap.IsPartOfTheLoop(new(0, 0)));
      Assert.False(complexMap.IsPartOfTheLoop(new(2, 4)));
      Assert.False(complexMap.IsPartOfTheLoop(new(4, 0)));
      Assert.False(complexMap.IsPartOfTheLoop(new(4, 4)));
    }

    [Fact]
    public void InsideTheLoopIsNotPartOfTheLoop()
    {
      Assert.False(simpleMap.IsPartOfTheLoop(new(2, 2)));
      Assert.False(complexMap.IsPartOfTheLoop(new(2, 2)));
    }

    [Fact]
    public void LoopBoundariesArePartOfTheLoop()
    {
      Assert.True(simpleMap.IsPartOfTheLoop(new(1, 1)));
      Assert.True(simpleMap.IsPartOfTheLoop(new(2, 1)));
      Assert.True(simpleMap.IsPartOfTheLoop(new(3, 2)));
      Assert.True(simpleMap.IsPartOfTheLoop(new(3, 3)));

      Assert.True(complexMap.IsPartOfTheLoop(new(0, 4)));
      Assert.True(complexMap.IsPartOfTheLoop(new(1, 1)));
      Assert.True(complexMap.IsPartOfTheLoop(new(2, 1)));
      Assert.True(complexMap.IsPartOfTheLoop(new(3, 0)));
      Assert.True(complexMap.IsPartOfTheLoop(new(4, 2)));
    }
  }

  [Fact]
  public void GetLoopLength()
  {
    Assert.Equal(8, simpleMap.LoopLength);
    Assert.Equal(16, complexMap.LoopLength);
  }

  [Fact]
  public void GetLoopBoundaries()
  {
    Assert.Equal(
      (new Coordinate(1, 1), new Coordinate(3, 3)),
      simpleMap.LoopBoundaries
    );
    Assert.Equal(
      (new Coordinate(0, 0), new Coordinate(4, 4)),
      complexMap.LoopBoundaries
    );
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
