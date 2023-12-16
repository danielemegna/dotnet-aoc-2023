namespace aoc2023.day3;

using Xunit;

public class EnginePartTest
{
  public class IsAGear()
  {

    [Fact]
    public void ReturnsFalseWithoutGearSymbol()
    {
      Assert.False(new EnginePart('@', []).IsAGear());
      Assert.False(new EnginePart('#', [817]).IsAGear());
      Assert.False(new EnginePart('&', [63, 2]).IsAGear());
      Assert.False(new EnginePart('%', [72, 12, 233]).IsAGear());
    }

    [Fact]
    public void ReturnsFalseWithGearSymbolAndLessThanTwoAjacentNumbers()
    {
      Assert.False(new EnginePart('*', []).IsAGear());
      Assert.False(new EnginePart('*', [349]).IsAGear());
    }

    [Fact]
    public void ReturnsFalseWithGearSymbolAndMoreThanTwoAjacentNumbers()
    {
      Assert.False(new EnginePart('*', [95, 1, 540]).IsAGear());
      Assert.False(new EnginePart('*', [29, 311, 2, 44]).IsAGear());
    }

    [Fact]
    public void ReturnsTrueWithGearSymbolAndExactlyTwoAjacentNumbers()
    {
      var part = new EnginePart('*', [51, 621]);
      Assert.True(part.IsAGear());
    }

  }

  public class GearRatio()
  {
    [Fact]
    public void ReturnsProductOfAdjacentNumbers()
    {
      var part = new EnginePart('*', [51, 621]);
      Assert.Equal(51 * 621, part.GearRatio());
    }

    [Fact]
    public void ReturnsProductOfAdjacentNumbersAlsoForNonGearParts()
    {
      var part = new EnginePart('@', [51, 21, 11]);
      Assert.Equal(51 * 21 * 11, part.GearRatio());
    }
  }

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
