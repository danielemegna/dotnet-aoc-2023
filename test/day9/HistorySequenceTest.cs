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

  [Fact]
  public void GuessNextNumberWithASimpleAritmethicProgression()
  {
    var historySequence = new HistorySequence(0, 3, 6, 9, 12, 15);
    Assert.Equal(18, historySequence.GuessNext());
  }

  [Fact]
  public void GuessNextNumberWithASecondOrderAritmethicProgression()
  {
    var historySequence = new HistorySequence(1, 3, 6, 10, 15, 21);
    Assert.Equal(28, historySequence.GuessNext());
  }

  [Fact]
  public void GuessNextNumberWithAThirdOrderAritmethicProgression()
  {
    var historySequence = new HistorySequence(10, 13, 16, 21, 30, 45);
    Assert.Equal(68, historySequence.GuessNext());
  }
}
