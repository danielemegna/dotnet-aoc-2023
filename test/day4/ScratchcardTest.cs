namespace aoc2023.day4;

using Xunit;

public class ScratchcardTest
{
  private Scratchcard s1 = new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);
  private Scratchcard s2 = new Scratchcard([13, 32, 20, 16, 61], [61, 30, 68, 82, 17, 32, 24, 19]);
  private Scratchcard s3 = new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);
  private Scratchcard s4 = new Scratchcard([31, 18, 13, 56, 72], [74, 77, 10, 23, 35, 67, 36, 11]);

  [Fact]
  public void GetWins()
  {
    AssertSetEqual([48, 86, 83, 17], s1.GetWins());
    AssertSetEqual([32, 61], s2.GetWins());
    AssertSetEqual([], s4.GetWins());
  }

  [Fact]
  public void Equality()
  {
    Assert.NotEqual(s1, s2);
    Assert.False(s1.Equals(s2));
    Assert.NotSame(s1, s2);

    Assert.Equal(s1, s3);
    Assert.True(s1.Equals(s3));
    Assert.NotSame(s1, s3);

    Assert.Same(s1, s1);
  }

  [Fact]
  public void HashCode()
  {
    Assert.NotEqual(s1.GetHashCode(), s2.GetHashCode());
    Assert.Equal(s1.GetHashCode(), s3.GetHashCode());
  }

  private static void AssertSetEqual(IEnumerable<int> expected, ISet<int> actual) =>
    Assert.Equal(expected.ToHashSet(), actual);

}
