namespace aoc2023.day1;

public class Trebuchet
{
  public enum Mode { ONLY_NUMBERS, NUMBERS_AND_SPELLED }

  private readonly string[] SORTED_SUPPORTED_WORDS = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

  public int SumOfCalibrationValuesFor(string[] inputLines, Mode mode)
  {
    return inputLines.Select((line) => CalibrationValueFromRow(line, mode)).Sum();
  }

  public int CalibrationValueFromRow(string inputLine, Mode mode)
  {
    string firstNumber = FirstNumberIn(inputLine, mode);
    string lastNumber = LastNumberIn(inputLine, mode);
    return int.Parse(firstNumber + lastNumber);
  }

  private string FirstNumberIn(string input, Mode mode)
  {
    return FirstNumberUsing(input, SORTED_SUPPORTED_WORDS, mode);
  }

  private string LastNumberIn(string input, Mode mode)
  {
    var reversedInput = Reverse(input);
    var reversedSortedSupportedWords = SORTED_SUPPORTED_WORDS.Select(Reverse).ToArray();
    return FirstNumberUsing(reversedInput, reversedSortedSupportedWords, mode);
  }

  private string FirstNumberUsing(string input, string[] sortedSupportedWords, Mode mode)
  {
    for (int inputCursor = 0; inputCursor < input.Length; inputCursor++)
    {
      char c = input[inputCursor];
      if (isAnInteger(c))
        return c.ToString();

      if (mode == Mode.ONLY_NUMBERS)
        continue;

      var substring = input.Substring(0, inputCursor + 1);
      for (int wordsCursor = 0; wordsCursor < sortedSupportedWords.Length; wordsCursor++)
      {
        var currentWord = sortedSupportedWords[wordsCursor];
        if (substring.Contains(currentWord))
          return (wordsCursor + 1).ToString();
      }
    }

    throw new Exception("Cannot find number in: " + input);
  }

  private bool isAnInteger(char c)
  {
    return int.TryParse(c.ToString(), out _);
  }

  private string Reverse(string value)
  {
    return new string(value.ToCharArray().Reverse().ToArray());
  }

}