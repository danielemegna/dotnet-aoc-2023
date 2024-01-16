
namespace aoc2023.day4;

public class Solver
{
  public int SumPointsOfScratchcards(string[] inputLines)
  {
    Scratchcard[] cards = ParseScratchcards(inputLines);
    return cards.Select(ScratchcardsEvaluator.PointsFor).Sum();
  }

  public int CollectedScratchards(string[] inputLines)
  {
    Scratchcard[] cards = ParseScratchcards(inputLines);
    var evaluator = new ScratchcardsEvaluator(cards);
    return cards.Length + cards.Select((card, index) =>
      evaluator.RecursiveWonScratchcards(card, cards.Skip(index + 1))
    ).Sum();
  }

  internal Scratchcard[] ParseScratchcards(string[] inputLines)
  {
    return inputLines.Select(line =>
    {
      var cardContentString = line.Split(":")[1];
      var splitOptions = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;
      var (winningNumbersString, cardNumbersString) = cardContentString.Split("|") switch { var a => (a[0], a[1]) };

      var winningNumbers = winningNumbersString.Split(" ", splitOptions).Select(int.Parse);
      var cardNumbers = cardNumbersString.Split(" ", splitOptions).Select(int.Parse);
      return new Scratchcard(winningNumbers, cardNumbers);
    }).ToArray();
  }

}