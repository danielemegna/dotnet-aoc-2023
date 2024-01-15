namespace aoc2023.day4;

using Xunit;

public class ScratchcardsEvaluatorTest
{
  private ScratchcardsEvaluator evaluator = new ScratchcardsEvaluator();

  public class PointsFor : ScratchcardsEvaluatorTest
  {
    [Fact]
    public void ZeroPointsWithNoWins()
    {
      var card = new Scratchcard([87, 83, 26, 28, 32], [88, 30, 70, 12, 93, 22, 82, 36]);
      var actual = evaluator.PointsFor(card);
      Assert.Equal(0, actual);
    }

    [Fact]
    public void OnePointWithASingleWin()
    {
      var card = new Scratchcard([36, 92, 73, 84, 69], [59, 84, 76, 51, 58, 5, 54, 83]);
      var actual = evaluator.PointsFor(card);
      Assert.Equal(1, actual);
    }

    [Fact]
    public void TwoPointsWithTwoWins()
    {
      var card = new Scratchcard([13, 32, 20, 16, 61], [61, 30, 68, 82, 17, 32, 24, 19]);
      var actual = evaluator.PointsFor(card);
      Assert.Equal(1 * 2, actual);
    }

    [Fact]
    public void FourPointsWithThreeWins_PointsAreDoubledForEveryWins()
    {
      var card = new Scratchcard([31, 18, 13, 56, 72], [74, 77, 31, 23, 13, 67, 36, 72]);
      var actual = evaluator.PointsFor(card);
      Assert.Equal(1 * 2 * 2, actual);
    }

    [Fact]
    public void EightPointsWithFourWins_PointsAreDoubledForEveryWins()
    {
      var card = new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]);
      var actual = evaluator.PointsFor(card);
      Assert.Equal(1 * 2 * 2 * 2, actual);
    }

  }

  public class RecursiveWonScratchcards : ScratchcardsEvaluatorTest
  {
    private Scratchcard[] cards = [
      new Scratchcard([41, 48, 83, 86, 17], [83, 86, 6, 31, 17, 9, 48, 53]),
      new Scratchcard([13, 32, 20, 16, 61], [61, 30, 68, 82, 17, 32, 24, 19]),
      new Scratchcard([1, 21, 53, 59, 44], [69, 82, 63, 72, 16, 21, 14, 1]),
      new Scratchcard([41, 92, 73, 84, 69], [59, 84, 76, 51, 58, 5, 54, 83]),
      new Scratchcard([87, 83, 26, 28, 32], [88, 30, 70, 12, 93, 22, 82, 36]),
      new Scratchcard([31, 18, 13, 56, 72], [74, 77, 10, 23, 35, 67, 36, 11]),
    ];

    [Fact]
    public void ZeroWithNoWins()
    {
      var card = cards[4];
      var rest = cards.Skip(5);

      var actual = evaluator.RecursiveWonScratchcards(card, rest);

      Assert.Equal(0, actual);
    }

    [Fact]
    public void OnePointWithASingleWin_WhenWonScratchcardDoNotWinMoreScratchcards()
    {
      var card = cards[3];
      var rest = cards.Skip(4);

      var actual = evaluator.RecursiveWonScratchcards(card, rest);

      Assert.Equal(1, actual);
    }
  }

}
