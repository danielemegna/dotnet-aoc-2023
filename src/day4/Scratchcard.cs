namespace aoc2023.day4;

public class Scratchcard(HashSet<int> winningNumbers, HashSet<int> numbers)
{
  public HashSet<int> WinningNumbers { get; } = winningNumbers;
  public HashSet<int> Numbers { get; } = numbers;

  public Scratchcard(IEnumerable<int> winningNumbers, IEnumerable<int> numbers)
    : this(winningNumbers.ToHashSet(), numbers.ToHashSet()) { }

  public ISet<int> GetWins() => WinningNumbers.Intersect(Numbers).ToHashSet();

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(Scratchcard)) return false;
    var otherCasted = (Scratchcard)other;

    return
      WinningNumbers.SetEquals(otherCasted.WinningNumbers) &&
      Numbers.SetEquals(otherCasted.Numbers);
  }

  public override int GetHashCode()
  {
    var comparer = HashSet<int>.CreateSetComparer();
    return (comparer.GetHashCode(WinningNumbers) * 2) + comparer.GetHashCode(Numbers);
  }
}
