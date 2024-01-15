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
    var wonCardsCount = card.GetWins().Count();
    var wonCards = rest.Take(wonCardsCount);

    return wonCardsCount + wonCards.Select((wonCard, index) =>
      RecursiveWonScratchcards(wonCard, rest.Skip(index + 1))
    ).Sum();
  }
}
