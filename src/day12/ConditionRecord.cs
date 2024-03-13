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

  internal bool? IsCompatibleWithDamagedSpringsGroup(string springsStatesToCheckString)
  {
    var springsStatesToCheck = SpringStatesToBoolean(springsStatesToCheckString);
    var damagedSpringsGroupsToHave = new Queue<int>(damagedSpringsGroups);

    int currentDamagedSpringGroupValue = 0;
    foreach (bool? state in springsStatesToCheck)
    {
      if (!state.HasValue)
      {
        if (currentDamagedSpringGroupValue > 0)
        {
          if (damagedSpringsGroupsToHave.Count == 0)
            return false;
          if (damagedSpringsGroupsToHave.Dequeue() < currentDamagedSpringGroupValue)
            return false;
        }
        return null;
      }

      if (!state.Value)
      {
        currentDamagedSpringGroupValue++;
        continue;
      }

      if (currentDamagedSpringGroupValue > 0)
      {
        if (damagedSpringsGroupsToHave.Count == 0)
          return false;
        if (damagedSpringsGroupsToHave.Dequeue() != currentDamagedSpringGroupValue)
          return false;

        currentDamagedSpringGroupValue = 0;
      }
    }

    if (currentDamagedSpringGroupValue > 0)
    {
      if (damagedSpringsGroupsToHave.Count == 0)
        return false;
      if (damagedSpringsGroupsToHave.Dequeue() != currentDamagedSpringGroupValue)
        return false;

    }

    return damagedSpringsGroupsToHave.Count == 0;
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
