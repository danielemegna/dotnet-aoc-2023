
namespace aoc2023.day12;

public class ConditionRecord
{
  private readonly bool?[] springsStates;
  private readonly int[] damagedSpringsGroups;

  public ConditionRecord(string springsStates, int[] damagedSpringsGroups)
  : this(
    springsStates
      .ToCharArray()
      .Select<char, bool?>(
        c => c switch { '.' => true, '#' => false, _ => null }
      ).ToArray(),
    damagedSpringsGroups
  )
  { }

  public ConditionRecord(bool?[] springsStates, int[] damagedSpringsGroups)
  {
    this.springsStates = springsStates;
    this.damagedSpringsGroups = damagedSpringsGroups;
  }

  public int PossibileArrangementsCount()
  {
    return 1;
  }
}