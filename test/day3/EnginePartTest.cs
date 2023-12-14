namespace aoc2023.day3;

using Xunit;

public class EnginePartTest {

    [Fact]
    public void WithoutAdjacentNumbers()
    {
      string[] inputMatrix = [
        ".....12",
        "93.*...",
        ".......",
      ];

      var actual = EnginePart.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithoutAdjacentNumberAtTheEdge()
    {
      string[] inputMatrix = [
        "....*",
        ".....",
        "#....",
      ];

      var actual = EnginePart.From(inputMatrix, new(4, 0));
      Assert.Equal('*', actual.Symbol);
      Assert.Equal([], actual.AdjacentNumbers);

      actual = EnginePart.From(inputMatrix, new(0, 2));
      Assert.Equal('#', actual.Symbol);
      Assert.Equal([], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberToTheRight()
    {
      string[] inputMatrix = [
        "......",
        "..*91.",
        "......",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([91], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberToTheRightAtTheEdge()
    {
      string[] inputMatrix = [
        ".....",
        "..*62",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([62], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberToTheLeft()
    {
      string[] inputMatrix = [
        "......",
        ".59*..",
        "......",
      ];

      var actual = EnginePart.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([59], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberToTheLeftAtTheEdge()
    {
      string[] inputMatrix = [
        ".....",
        "6*...",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(1, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([6], actual.AdjacentNumbers);
    }
}