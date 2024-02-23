namespace aoc2023.day9;

public class HistorySequence(params int[] numbers)
{
  private readonly int[] numbers = numbers;

  public int GuessNext()
  {
    return GuessNextWith(numbers.ToList());
  }

  private int GuessNextWith(List<int> sequence)
  {
    if (sequence.First() == sequence.Last())
      return sequence[0];

    List<int> list = new List<int>();
    for (int i = 0; i < sequence.Count-1; i++)
    {
      list.Add(sequence[i+1] - sequence[i]);
    }
    return sequence.Last() + GuessNextWith(list);
  }
}