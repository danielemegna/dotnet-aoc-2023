namespace aoc2023.day4;

public class ScratchcardsEvaluator
{
  public int PointsFor(Scratchcard card)
  {
    var winsCount = card.GetWins().Count;
    return (int)Math.Pow(2, winsCount-1);
  }
}