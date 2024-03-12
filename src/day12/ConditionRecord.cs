namespace aoc2023.day12;

public class ConditionRecord
{
  private readonly bool?[] springsStates;
  private readonly int[] damagedSpringsGroups;

  public ConditionRecord(string springsStates, int[] damagedSpringsGroups)
  : this(SpringStatesToBoolean(springsStates), damagedSpringsGroups) { }

  public ConditionRecord(bool?[] springsStates, int[] damagedSpringsGroups)
  {
    this.springsStates = springsStates;
    this.damagedSpringsGroups = damagedSpringsGroups;
  }

  public int PossibileArrangementsCount()
  {
    return 1;
  }

  internal bool IsCompatibleWithDamagedSpringsGroup(string springsStates)
  {
    var booleanSpringsStates = SpringStatesToBoolean(springsStates);

    List<int> readDamagedSpringsGroups = [];
    int currentDamagedSpringGroupValue = 0;
    foreach (bool? state in booleanSpringsStates)
    {
      if (!state.HasValue)
        throw new SystemException("Cannot check compatibility for uncompleted springs states array");

      if (!state.Value)
      {
        currentDamagedSpringGroupValue++;
        continue;
      }

      if(currentDamagedSpringGroupValue > 0) {
        readDamagedSpringsGroups.Add(currentDamagedSpringGroupValue);
        currentDamagedSpringGroupValue = 0;
        // TODO optimize with break on incompatibility
      }
    }

    return readDamagedSpringsGroups.ToArray() == this.damagedSpringsGroups;
  }

  private static bool?[] SpringStatesToBoolean(string springsStates)
  {
    return springsStates
      .ToCharArray()
      .Select<char, bool?>(
        c => c switch { '.' => true, '#' => false, _ => null }
      ).ToArray();
  }
}
