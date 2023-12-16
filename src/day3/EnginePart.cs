namespace aoc2023.day3;

public record EnginePart(char Symbol, HashSet<int> AdjacentNumbers)
{
  public bool IsAGear() => Symbol == EnginePartFactory.STAR_CHAR_CODE && AdjacentNumbers.Count == 2;
  public int GearRatio() => AdjacentNumbers.Aggregate((a, b) => a * b);

  public virtual bool Equals(EnginePart? other)
  {
    if ((object)this == other) return true;
    if (other is null) return false;
    if (EqualityContract != other.EqualityContract) return false;

    return
      Symbol.Equals(other.Symbol) &&
      AdjacentNumbers.SetEquals(other.AdjacentNumbers);
  }

}
