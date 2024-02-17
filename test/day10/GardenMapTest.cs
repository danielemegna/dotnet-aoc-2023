namespace aoc2023.day10;

using Xunit;

public class GardenMapTest {

    [Fact]
    public void BuildFromArrayOfStrings() {
      var actual = GardenMap.From(SolverTest.COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES);

      var expected = new GardenMap([
        ['.','.','F','7','.'],
        ['.','F','J','|','.'],
        ['S','J','.','L','7'],
        ['|','F','-','-','J'],
        ['L','J','.','.','.']
      ]);
      Assert.Equal(expected, actual);
    }

    [Fact(Skip = "WIP")]
    public void ConnectionsForPoint()
    {
      var map = new GardenMap([
        ['.','.','F','7','.'],
        ['.','F','J','|','.'],
        ['S','J','.','L','7'],
        ['|','F','-','-','J'],
        ['L','J','.','.','.']
      ]);

      var actual = map.ConnectionsFor(new(0, 2));

      Coordinate leftExpected = new(0, 3);
      Coordinate rightExpected = new(1, 2);
      Assert.Equal((leftExpected, rightExpected), actual);
    }

    [Fact]
    public void Equality()
    {
      var first = new GardenMap([
        ['.','.','.','.','.'],
        ['.','S','-','7','.'],
        ['.','|','.','|','.'],
        ['.','L','-','J','.'],
        ['.','.','.','.','.']
      ]);

      var second = new GardenMap([
        ['.','.','.','.','.'],
        ['.','S','-','7','.'],
        ['.','|','.','|','.'],
        ['.','L','-','J','.'],
        ['.','.','.','.','.']
      ]);
      
      var third = new GardenMap([
        ['.','.'],
        ['.','S'],
      ]);

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
