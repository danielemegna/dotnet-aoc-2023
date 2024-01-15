namespace aoc2023.day4;

public class ScratchcardsEvaluator
{
  public int PointsFor(Scratchcard card)
  {
    var winsCount = card.GetWins().Count;
    return (int)Math.Pow(2, winsCount - 1);
  }

  public int RecursiveWonScratchcards(Scratchcard card, IEnumerable<Scratchcard> rest)
  {
    return PointsFor(card);
  }
}
