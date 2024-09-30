namespace aoc2023.day15;

using Xunit;

public class HolidayASCIIStringHelperTest
{
  private readonly HolidayASCIIStringHelper helper = new HolidayASCIIStringHelper();

  [Fact]
  public void GetHashCodeOfSingleLetter()
  {
    Assert.Equal(200, helper.HashCodeOf("H"));
  }

  [Fact]
  public void GetHashCodeOfHASHString()
  {
    Assert.Equal(52, helper.HashCodeOf("HASH"));
  }

  [Fact]
  public void GetHashCodeOfProvidedExampleStrings()
  {
    Assert.Equal(30, helper.HashCodeOf("rn=1"));
    Assert.Equal(253, helper.HashCodeOf("cm-"));
    Assert.Equal(97, helper.HashCodeOf("qp=3"));
    Assert.Equal(47, helper.HashCodeOf("cm=2"));
    Assert.Equal(214, helper.HashCodeOf("pc=6"));
    Assert.Equal(231, helper.HashCodeOf("ot=7"));
  }
}
