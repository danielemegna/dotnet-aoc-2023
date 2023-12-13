namespace aoc2023.day3;

using Xunit;

public class EnginePartTest {

    [Fact]
    public void EnginePartWithoutAdjacentNumbers()
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
    public void EnginePartWithoutAdjacentNumberAtTheEdge()
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
    public void EnginePartWithOneAdjacentNumberToTheRight()
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
    public void EnginePartWithOneAdjacentNumberToTheRightAtTheEdge()
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
    public void EnginePartWithOneAdjacentNumberToTheLeft()
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
    public void EnginePartWithOneAdjacentNumberToTheLeftAtTheEdge()
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