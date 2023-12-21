namespace aoc2023.day4;

using Xunit;

public class ScratchcardTest
{

  [Fact]
  public void Equality()
  {
    var s1 = new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);
    var s2 = new Scratchcard([13, 32, 20, 16, 61], [61, 30, 68, 82, 17, 32, 24, 19]);
    var s3 = new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);
    Assert.NotEqual(s1, s2);
    Assert.False(s1.Equals(s2));
    Assert.Equal(s1, s3);
    Assert.True(s1.Equals(s3));
  }

}