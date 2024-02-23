namespace aoc2023.day9;

public class Solver
{
  public int SumOfNextHistoryValues(string[] inputLines)
  {
    return inputLines
      .Select(HistorySequenceFrom)
      .Select(s => s.GuessNext())
      .Sum();
  }

  private HistorySequence HistorySequenceFrom(string sequenceString) {
    var numbers = sequenceString.Split(" ").Select(int.Parse);
    return new HistorySequence(numbers.ToArray());
  }
}