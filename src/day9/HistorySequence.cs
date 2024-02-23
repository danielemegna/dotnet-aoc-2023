namespace aoc2023.day9;

public class HistorySequence(params int[] numbers)
{
  private readonly int[] numbers = numbers;

  public int GuessNext() => GuessNextWith(numbers.ToList());
  public int GuessPrevious() => GuessPreviousWith(numbers.ToList());

  private int GuessNextWith(List<int> sequence)
  {
    if (sequence.First() == sequence.Last())
      return sequence[0];

    var differencesSequence = DifferencesSequence(sequence);
    return sequence.Last() + GuessNextWith(differencesSequence);
  }

  private int GuessPreviousWith(List<int> sequence)
  {
    if (sequence.First() == sequence.Last())
      return sequence[0];

    var differencesSequence = DifferencesSequence(sequence);
    return sequence.First() - GuessPreviousWith(differencesSequence);
  }

  private List<int> DifferencesSequence(List<int> sequence)
  {
    List<int> list = [];
    for (int i = 1; i < sequence.Count; i++)
    {
      int previousNumber = sequence[i - 1];
      int currentNumber = sequence[i];
      list.Add(currentNumber - previousNumber);
    }
    return list;

  }
}
