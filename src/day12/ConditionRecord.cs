
namespace aoc2023.day12;

public class ConditionRecord
{
  private readonly char[] springsStates;
  private readonly int[] damagedSpringsGroups;

  public ConditionRecord(string springsStates, int[] damagedSpringsGroups)
  {
    this.springsStates = springsStates.ToCharArray();
    this.damagedSpringsGroups = damagedSpringsGroups;
  }


  public int PossibileArrangementsCount()
  {
    return 1;
  }
}