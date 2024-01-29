namespace aoc2023.day7;

public class Solver()
{
  public long TotalWinningsOfHands(string[] inputLines)
  {
    Bet[] bets = ParseBetList(inputLines);
    SortBetsByHandsRank(ref bets);

    return bets
      .Select((bet, index) => bet.Amount * (index + 1))
      .Sum();
  }

  internal Bet[] ParseBetList(string[] inputLines)
  {
    return inputLines.Select(line =>
    {
      string[] lineParts = line.Split(" ");
      return new Bet(
        Hand: CardsHand.From(lineParts[0]),
        Amount: int.Parse(lineParts[1])
    );
    }).ToArray();
  }

  internal void SortBetsByHandsRank(ref Bet[] bets)
  {
    Array.Sort(bets, (a,b) => a.Hand.CompareTo(b.Hand));
  }

}