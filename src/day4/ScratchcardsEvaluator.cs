namespace aoc2023.day4;

public class ScratchcardsEvaluator(Scratchcard[] cards)
{
  private readonly Scratchcard[] scratchcards = cards;

  public static int PointsFor(Scratchcard card)
  {
    var winsCount = card.GetWins().Count;
    return (int)Math.Pow(2, winsCount - 1);
  }

  public int TotalWonScratchcards()
  {
    return Enumerable.Range(0, scratchcards.Length - 1)
      .Reverse()
      .Select(WonScratchcardsByScratchcardAt)
      .Sum();
  }

  internal int WonScratchcardsByScratchcardAt(int index)
  {
    var card = scratchcards[index];
    var rest = scratchcards.Skip(index + 1);
    return RecursiveWonScratchcards(card, rest);
  }

  private int RecursiveWonScratchcards(Scratchcard card, IEnumerable<Scratchcard> rest)
  {
    var wonCardsCount = card.GetWins().Count;
    var wonCards = rest.Take(wonCardsCount);

    return wonCardsCount + wonCards.Select((wonCard, index) =>
      RecursiveWonScratchcards(wonCard, rest.Skip(index + 1))
    ).Sum();
  }

}
