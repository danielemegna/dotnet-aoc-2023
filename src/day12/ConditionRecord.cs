namespace aoc2023.day12;

public class ConditionRecord
{
  private readonly bool?[] springsStates;
  private readonly int[] damagedSpringsGroups;

  public ConditionRecord(string springsStates, int[] damagedSpringsGroups)
  {
    this.springsStates = SpringStatesToBoolean(springsStates);
    this.damagedSpringsGroups = damagedSpringsGroups;
  }

  public int PossibileArrangementsCount()
  {
    return CountPossibleArragementsFor(springsStates);
  }

  private int CountPossibleArragementsFor(bool?[] springsStatesToCheck)
  {
    var compatibilityCheck = IsCompatibleWithDamagedSpringsGroup(springsStatesToCheck);
    if (compatibilityCheck.HasValue)
      return compatibilityCheck.Value ? 1 : 0;

    var firstUnknownStateIndex = Array.IndexOf(springsStatesToCheck, null);
    bool?[] copyTrue = (bool?[])springsStatesToCheck.Clone();
    bool?[] copyFalse = (bool?[])springsStatesToCheck.Clone();
    copyTrue[firstUnknownStateIndex] = true;
    copyFalse[firstUnknownStateIndex] = false;

    return CountPossibleArragementsFor(copyTrue) + CountPossibleArragementsFor(copyFalse);
  }

  internal bool? IsCompatibleWithDamagedSpringsGroup(string springsStatesToCheckString)
  {
    var springsStatesToCheck = SpringStatesToBoolean(springsStatesToCheckString);
    return IsCompatibleWithDamagedSpringsGroup(springsStatesToCheck);
  }

  private bool? IsCompatibleWithDamagedSpringsGroup(bool?[] springsStatesToCheck)
  {
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
