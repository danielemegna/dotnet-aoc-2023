namespace aoc2023.day9;

internal class HistorySequence
{
  private readonly int[] numbers;

  public HistorySequence(params int[] numbers)
  {
    this.numbers = numbers;
  }

  public int GuessNext()
  {
    List<int> list = new List<int>();
    for (int i = 0; i < numbers.Length-1; i++)
    {
      list.Add(numbers[i] - numbers[i+1]);
    }

    return numbers[0];
  }
}