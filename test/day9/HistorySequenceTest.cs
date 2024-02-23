namespace aoc2023.day9;

using Xunit;

public class HistorySequenceTest
{
  public class GuessNext()
  {
    [Fact]
    public void WithAllThreeSequence()
    {
      var historySequence = new HistorySequence(3, 3, 3, 3, 3);
      Assert.Equal(3, historySequence.GuessNext());
    }

    [Fact]
    public void WithASimpleAritmethicProgression()
    {
      var historySequence = new HistorySequence(0, 3, 6, 9, 12, 15);
      Assert.Equal(18, historySequence.GuessNext());
    }

    [Fact]
    public void WithASecondOrderAritmethicProgression()
    {
      var historySequence = new HistorySequence(1, 3, 6, 10, 15, 21);
      Assert.Equal(28, historySequence.GuessNext());
    }

    [Fact]
    public void WithAThirdOrderAritmethicProgression()
    {
      var historySequence = new HistorySequence(10, 13, 16, 21, 30, 45);
      Assert.Equal(68, historySequence.GuessNext());
    }
  }

  public class GuessPrevious()
  {
    [Fact]
    public void WithAllThreeSequence()
    {
      var historySequence = new HistorySequence(3, 3, 3, 3, 3);
      Assert.Equal(3, historySequence.GuessPrevious());
    }

    [Fact]
    public void WithASimpleAritmethicProgression()
    {
      var historySequence = new HistorySequence(0, 3, 6, 9, 12, 15);
      Assert.Equal(-3, historySequence.GuessPrevious());
    }

    [Fact]
    public void WithASecondOrderAritmethicProgression()
    {
      var historySequence = new HistorySequence(1, 3, 6, 10, 15, 21);
      Assert.Equal(0, historySequence.GuessPrevious());
    }

    [Fact]
    public void WithAThirdOrderAritmethicProgression()
    {
      var historySequence = new HistorySequence(10, 13, 16, 21, 30, 45);
      Assert.Equal(5, historySequence.GuessPrevious());
    }
  }
}
