namespace aoc2023.day12;

using Xunit;

public class ConditionRecordTest
{

  public class PossibileArrangementsCount
  {

    [Fact]
    public void JustOnePossibileArrangements()
    {
      var record = new ConditionRecord("???.###", [1, 1, 3]);
      Assert.Equal(1, record.PossibileArrangementsCount());
    }

    [Fact]
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

    [Fact]
    public void MoreComplexFourPossibileArrangements()
    {
      var record = new ConditionRecord("????.######..#####.", [1, 6, 5]);
      Assert.Equal(4, record.PossibileArrangementsCount());
    }

    [Fact]
    public void TenPossibileArrangements()
    {
      var record = new ConditionRecord("?###????????", [3, 2, 1]);
      Assert.Equal(10, record.PossibileArrangementsCount());
    }

    [Fact]
    public void LongerWithManyPossibileArrangements()
    {
      var record = new ConditionRecord(
        "????.#...#...?????.#...#...?????.#...#...?????.#...#...?????.#...#...",
        [4, 1, 1, 4, 1, 1, 4, 1, 1, 4, 1, 1, 4, 1, 1]
      );
      Assert.Equal(16, record.PossibileArrangementsCount());
    }

    [Fact]
    public void LongerOnePossibileArrangements()
    {
      var record = new ConditionRecord(
        "???.###????.###????.###????.###????.###",
        [1, 1, 3, 1, 1, 3, 1, 1, 3, 1, 1, 3, 1, 1, 3]
      );
      Assert.Equal(1, record.PossibileArrangementsCount());
    }

    [Fact]
    public void OnlyThreePossibleArrangments()
    {
      var record = new ConditionRecord("?.##???#???#??#.??", [2, 8, 1]);
      Assert.Equal(3, record.PossibileArrangementsCount());
    }

    [Fact]
    public void ManyPossibileArrangements()
    {
      var record = new ConditionRecord(
        "?.##???#???#??#.????.##???#???#??#.????.##???#???#??#.????.##???#???#??#.????.##???#???#??#.??",
        [2, 8, 1, 2, 8, 1, 2, 8, 1, 2, 8, 1, 2, 8, 1]
      );
      Assert.Equal(1875, record.PossibileArrangementsCount());
    }

    [Fact]
    public void LotOfPossibileArrangements()
    {
      var record = new ConditionRecord(
        "????.######..#####.?????.######..#####.?????.######..#####.?????.######..#####.?????.######..#####.",
        [1, 6, 5, 1, 6, 5, 1, 6, 5, 1, 6, 5, 1, 6, 5]
      );
      Assert.Equal(2500, record.PossibileArrangementsCount());
    }

    [Fact(Skip = "WIP: very slow, we have to change algorhytm")]
    public void TonsOfPossibileArrangements()
    {
      var record = new ConditionRecord(
        "?###??????????###??????????###??????????###??????????###????????",
        [3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2, 1]
      );
      Assert.Equal(506250, record.PossibileArrangementsCount());
    }

  }

  public class DamagedSpringsGroupCompatibilityCheck
  {

    [Fact]
    public void NotCompatibleWithSimpleSingleGroup()
    {
      var record = new ConditionRecord("", [2]);
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("#."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#"));
    }

    [Fact]
    public void CompatibleWithSimpleSingleGroup()
    {
      var record = new ConditionRecord("", [2]);
      Assert.True(record.IsCompatibleWithDamagedSpringsGroup("##"));
    }

    [Fact]
    public void NotCompatibleWithTwoGroupsOfOnes()
    {
      var record = new ConditionRecord("", [1, 1]);
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("###"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("##."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".##"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("#.."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("..#"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("..."));
    }

    [Fact]
    public void CompatibleWithTwoGroupsOfOnes()
    {
      var record = new ConditionRecord("", [1, 1]);
      Assert.True(record.IsCompatibleWithDamagedSpringsGroup("#.#"));
    }

    [Fact]
    public void NotCompatibleWithThreeGroups()
    {
      var record = new ConditionRecord("", [1, 1, 3]);

      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".............."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("...........##."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("..........###."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".....##...###."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#........###."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("..#..##...###."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".##..#....###."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#....#....##."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".##........##."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#...#..###..#"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#...#.###..#."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("##############"));
    }

    [Fact]
    public void CompatibleWithThreeGroups()
    {
      var record = new ConditionRecord("", [1, 1, 3]);

      Assert.True(record.IsCompatibleWithDamagedSpringsGroup(".#...#....###."));
      Assert.True(record.IsCompatibleWithDamagedSpringsGroup(".#....#...###."));
      Assert.True(record.IsCompatibleWithDamagedSpringsGroup("..#..#....###."));
      Assert.True(record.IsCompatibleWithDamagedSpringsGroup("..#...#...###."));
    }

    [Fact]
    public void NotCompatibleWithFourGroups()
    {
      var record = new ConditionRecord("", [1, 3, 1, 6]);

      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#.#.#.#.#.#.#."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#.#.#.#.#.#.##"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("##.#.#.#.#.#.##"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#.#.#.#.######"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("######.#.###.#."));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("##.###.#.######"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#.###.#..#####"));
    }

    [Fact]
    public void CompatibleWithFourGroups()
    {
      var record = new ConditionRecord("", [1, 3, 1, 6]);
      Assert.True(record.IsCompatibleWithDamagedSpringsGroup(".#.###.#.######"));
      Assert.True(record.IsCompatibleWithDamagedSpringsGroup("#.###..#.######"));
    }

    [Fact]
    public void UncompletedSpringsStatesShouldReturnFalseIfNotCompatibleBeforeTheUncompletePart()
    {
      var record = new ConditionRecord("", [1, 3, 1, 6]);
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("##.#?#?#?#?#?#?"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("##?#?#?#?#?#?#?"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".###?#?#?#?#?#?"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#.#.#?#?#?#?#?"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup("######?#.#.#.#?"));
      Assert.False(record.IsCompatibleWithDamagedSpringsGroup(".#.#####.#?#?#?"));
    }

    [Fact]
    public void UncompletedSpringsStatesShouldReturnNullIfCompatibleUntilTheUncompletePart()
    {
      var record = new ConditionRecord("", [1, 3, 1, 6]);
      Assert.Null(record.IsCompatibleWithDamagedSpringsGroup("?#?#?#?#?#?#?#?"));
      Assert.Null(record.IsCompatibleWithDamagedSpringsGroup(".#?#?#?#?#?#?#?"));
      Assert.Null(record.IsCompatibleWithDamagedSpringsGroup(".#.###?#?#?#?#?"));
      Assert.Null(record.IsCompatibleWithDamagedSpringsGroup(".#.###.#?#?#?#?"));
      Assert.Null(record.IsCompatibleWithDamagedSpringsGroup(".#.###.#.#####?"));
    }

  }

}
