namespace aoc2023.day4;

using Xunit;

public class ScratchcardTest
{
  private Scratchcard s1 = new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);
  private Scratchcard s2 = new Scratchcard([13, 32, 20, 16, 61], [61, 30, 68, 82, 17, 32, 24, 19]);
  private Scratchcard s3 = new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);

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

}
