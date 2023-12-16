namespace aoc2023.day3;

using Xunit;

public class EnginePartFactoryTest
{

  [Fact]
  public void WithoutAdjacentNumbers()
  {
    string[] inputMatrix = [
      ".....12",
      "93.*...",
      ".......",
    ];

    var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

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

    var actual = EnginePartFactory.From(inputMatrix, new(4, 0));
    Assert.Equal('*', actual.Symbol);
    Assert.Equal([], actual.AdjacentNumbers);

    actual = EnginePartFactory.From(inputMatrix, new(0, 2));
    Assert.Equal('#', actual.Symbol);
    Assert.Equal([], actual.AdjacentNumbers);
  }

  [Fact]
  public void WithSomeAdjacentNumbers()
  {
    string[] inputMatrix = [
      "....312",
      "93.*27.",
      "..189..",
    ];

    var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

    Assert.Equal('*', actual.Symbol);
    Assert.Equal([27, 312, 189], actual.AdjacentNumbers);
  }

  public class RightAndLeftAdjacentNumbers
  {

    [Fact]
    public void WithOneAdjacentNumberToTheRight()
    {
      string[] inputMatrix = [
        "......",
        "..*91.",
        "......",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([91], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberToTheRightAtTheEdge()
    {
      string[] inputMatrix = [
        ".....",
        "..*62",
        ".....",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([62], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberToTheLeft()
    {
      string[] inputMatrix = [
        "......",
        ".59*..",
        "......",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([59], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneAdjacentNumberToTheLeftAtTheEdge()
    {
      string[] inputMatrix = [
        ".....",
        "6*...",
        ".....",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(1, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([6], actual.AdjacentNumbers);
    }
  }

  public class AboveAdjacentNumbers
  {

    [Fact]
    public void WithOne()
    {
      string[] inputMatrix = [
        "..30.",
        "..*..",
        ".....",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([30], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneStartingBefore()
    {
      string[] inputMatrix = [
        ".78..",
        "..*..",
        ".....",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([78], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneStartingFarBefore()
    {
      string[] inputMatrix = [
        ".54...",
        "...*..",
        "......",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([54], actual.AdjacentNumbers);
    }


    [Fact]
    public void WithOneStartingAfter()
    {
      string[] inputMatrix = [
        "...57.",
        "..*...",
        "......",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([57], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneBig()
    {
      string[] inputMatrix = [
        ".631575.",
        "...*....",
        "........",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([631575], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneInLeftCorner()
    {
      string[] inputMatrix = [
        "89...",
        "..*..",
        ".....",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([89], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneInRightCorner()
    {
      string[] inputMatrix = [
        "...13",
        "..*..",
        ".....",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([13], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithMultiple()
    {
      string[] inputMatrix = [
        ".56.227.",
        "...*....",
        "........",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([56, 227], actual.AdjacentNumbers);
    }
  }

  public class BelowAdjacentNumbers
  {

    [Fact]
    public void WithOne()
    {
      string[] inputMatrix = [
        ".....",
        "..*..",
        "..64.",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([64], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneStartingBefore()
    {
      string[] inputMatrix = [
        ".....",
        "..*..",
        ".23..",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([23], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneStartingFarBefore()
    {
      string[] inputMatrix = [
        "......",
        "...*..",
        ".68...",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([68], actual.AdjacentNumbers);
    }


    [Fact]
    public void WithOneStartingAfter()
    {
      string[] inputMatrix = [
        "......",
        "..*...",
        "...18.",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([18], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneBig()
    {
      string[] inputMatrix = [
        "........",
        "...*....",
        ".316935.",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([316935], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithVeryBigOne()
    {
      string[] inputMatrix = [
        "........",
        "...*....",
        "19171603",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(3, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([19171603], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneInLeftCorner()
    {
      string[] inputMatrix = [
        ".....",
        "..*..",
        "43...",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([43], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithOneInRightCorner()
    {
      string[] inputMatrix = [
        ".....",
        "..*..",
        "...74",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(2, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([74], actual.AdjacentNumbers);
    }

    [Fact]
    public void WithMultiple()
    {
      string[] inputMatrix = [
        "........",
        "....*...",
        ".313.79.",
      ];

      var actual = EnginePartFactory.From(inputMatrix, new(4, 1));

      Assert.Equal('*', actual.Symbol);
      Assert.Equal([313, 79], actual.AdjacentNumbers);
    }
  }

}
