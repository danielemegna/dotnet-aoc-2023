namespace aoc2023.day4;

public class ScratchcardsEvaluator(Scratchcard[] cards)
{
  private readonly Scratchcard[] scratchcards = cards;
  private readonly Dictionary<int, int> wonScratchcardsCache = [];

  public static int PointsFor(Scratchcard card)
  {
    var winsCount = card.GetWins().Count;
    return (int)Math.Pow(2, winsCount - 1);
  }

  public int TotalWonScratchcards()
  {
    return WonScratchcardsInRange(0, scratchcards.Length - 1);
  }

  private int WonScratchcardsInRange(int fromIndex, int count)
  {
    return Enumerable.Range(fromIndex, count)
      .Reverse()
      .Select(WonScratchcardsByScratchcardAt)
      .Sum();
  }

  internal int WonScratchcardsByScratchcardAt(int index)
  {
    if (wonScratchcardsCache.ContainsKey(index))
      return wonScratchcardsCache[index];

    var card = scratchcards[index];
    var wonByCard = card.GetWins().Count;
    var wonByChildren = WonScratchcardsInRange(index + 1, wonByCard);

    var result = wonByCard + wonByChildren;
    wonScratchcardsCache[index] = result;
    return result;
  }

}
