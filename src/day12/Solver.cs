
namespace aoc2023.day12;

public class Solver
{
  public int SumOfPossibleArrangements(string[] inputLines)
  {
    return inputLines
      .Select(ConditionRecordFrom)
      .Select(record => record.PossibileArrangementsCount())
      .Sum();
  }

  private ConditionRecord ConditionRecordFrom(string value)
  {
    var (springsStatesString, damagedSpringsGroupsString) = value.Split(' ') switch { var a => (a[0], a[1]) };
    var damagedSpringsGroups = damagedSpringsGroupsString.Split(',').Select(int.Parse).ToArray();
    return new ConditionRecord(springsStatesString, damagedSpringsGroups);
  }
}
