namespace aoc2023.day12;

using Xunit;

public class ConditionRecordTest
{

  [Fact]
  public void JustOnePossibileArrangements()
  {
    var record = new ConditionRecord("???.###", [1, 1, 3]);
    Assert.Equal(1, record.PossibileArrangementsCount());
  }

  [Fact(Skip = "WIP")]
  public void FourPossibileArrangements()
  {
    var record = new ConditionRecord(".??..??...?##.", [1, 1, 3]);
    Assert.Equal(4, record.PossibileArrangementsCount());
  }

  [Fact]
  public void MoreComplexOnePossibileArrangements()
  {
    var record = new ConditionRecord("?#?#?#?#?#?#?#?", [1, 3, 1, 6]);
    Assert.Equal(1, record.PossibileArrangementsCount());
    record = new ConditionRecord("????.#...#...", [4, 1, 1]);
    Assert.Equal(1, record.PossibileArrangementsCount());
  }

  [Fact(Skip = "WIP")]
  public void MoreComplexFourPossibileArrangements()
  {
    var record = new ConditionRecord("????.######..#####.", [1, 6, 5]);
    Assert.Equal(4, record.PossibileArrangementsCount());
  }

  [Fact(Skip = "WIP")]
  public void TenPossibileArrangements()
  {
    var record = new ConditionRecord("?###????????", [3, 2, 1]);
    Assert.Equal(10, record.PossibileArrangementsCount());
  }

}