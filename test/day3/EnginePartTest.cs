namespace aoc2023.day3;

using Xunit;

public class EnginePartTest
{

  public class Equality()
  {

    [Fact]
    public void SameSymbolWithoutAdjacent()
    {
      var firstPart = new EnginePart('#', []);
      var secondPart = new EnginePart('#', []);
      Assert.Equal(firstPart, secondPart);
      Assert.True(firstPart.Equals(secondPart));
    }

    [Fact]
    public void DifferentSymbolWithoutAdjacent()
    {
      var firstPart = new EnginePart('@', []);
      var secondPart = new EnginePart('#', []);
      Assert.NotEqual(firstPart, secondPart);
      Assert.False(firstPart.Equals(secondPart));
    }

    [Fact]
    public void SameSymbolDifferentAdjacent()
    {
      var firstPart = new EnginePart('#', [123]);
      var secondPart = new EnginePart('#', [123, 32]);
      Assert.NotEqual(firstPart, secondPart);
      Assert.False(firstPart.Equals(secondPart));
    }

    [Fact]
    public void SameSymbolAndAdjacent()
    {
      var firstPart = new EnginePart('#', [93, 12]);
      var secondPart = new EnginePart('#', [93, 12]);
      Assert.Equal(firstPart, secondPart);
      Assert.True(firstPart.Equals(secondPart));
    }

    [Fact]
    public void SameSymbolAndAdjacentInDifferentOrder()
    {
      var firstPart = new EnginePart('#', [123, 85]);
      var secondPart = new EnginePart('#', [85, 123]);
      Assert.Equal(firstPart, secondPart);
      Assert.True(firstPart.Equals(secondPart));
    }

  }
  
}
