namespace aoc2023.day7;

public class Solver()
{
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

  internal void SortCardsHandsByRank(ref CardsHand[] cardsHands)
  {
    Array.Sort(cardsHands);
  }
}