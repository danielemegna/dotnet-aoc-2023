namespace aoc2023.day3;

using Xunit;

public class EnginePartTest {

    [Fact]
    public void EnginePartWithoutAdjacentNumber()
    {
      string[] inputMatrix = [
        ".....",
        "..*..",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([], actual.AdjacentNumbers);
    }

    [Fact]
    public void EnginePartWithoutAdjacentNumberAtTheEdge()
    {
      string[] inputMatrix = [
        ".....",
        "....*",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(4, 1));

      Assert.Equal('*', actual.Symbol);
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
}