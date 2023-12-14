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

    [Fact]
    public void WithOneAdjacentNumberAbove()
    {
      string[] inputMatrix = [
        "..30.",
        "..*..",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([30], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberAboveStartingBefore()
    {
      string[] inputMatrix = [
        ".78..",
        "..*..",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([78], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberAboveStartingFarBefore()
    {
      string[] inputMatrix = [
        ".54...",
        "...*..",
        "......",
      ];

      var actual = EnginePart.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([54], actual.AdjacentNumbers);
    }


    [Fact]
    public void WithOneAdjacentNumberAboveStartingAfter()
    {
      string[] inputMatrix = [
        "...57.",
        "..*...",
        "......",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([57], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneBigAdjacentNumberAbove()
    {
      string[] inputMatrix = [
        ".631575.",
        "...*....",
        "........",
      ];

      var actual = EnginePart.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([631575], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberAboveInLeftCorner()
    {
      string[] inputMatrix = [
        "89...",
        "..*..",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([89], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberAboveInRightCorner()
    {
      string[] inputMatrix = [
        "...13",
        "..*..",
        ".....",
      ];

      var actual = EnginePart.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([13], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithMultipleAdjacentNumberAbove()
    {
      string[] inputMatrix = [
        ".56.227.",
        "...*....",
        "........",
      ];

      var actual = EnginePart.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal<int[]>([56, 227], actual.AdjacentNumbers);
    }
}