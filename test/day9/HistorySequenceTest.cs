namespace aoc2023.day9;

using Xunit;

public class HistorySequenceTest
{
  [Fact]
  public void GuessNextNumberWithAllThreeSequence()
  {
    var historySequence = new HistorySequence(3, 3, 3, 3, 3);
    Assert.Equal(3, historySequence.GuessNext());
  }
}
