namespace aoc2023.day4;

public record Scratchcard(HashSet<int> WinningNumbers, HashSet<int> Numbers)
{

  public virtual bool Equals(Scratchcard? other)
  {
    if ((object)this == other) return true;
    if (other is null) return false;

    return
      WinningNumbers.SetEquals(other.WinningNumbers) &&
      Numbers.SetEquals(other.Numbers);
  }

}