namespace aoc2023;


public class Trebuchet
{
  public enum Mode { ONLY_NUMBERS, NUMBERS_AND_SPELLED }

  public int SumOfCalibrationValuesFor(string[] inputLines, Mode mode)
  {
    return inputLines.Select((line) => CalibrationValueFromRow(line, mode)).Sum();
  }

  public int CalibrationValueFromRow(string inputLine, Mode mode)
  {
    string firstNumber = FirstNumberIn(inputLine, mode, false);
    string lastNumber = FirstNumberIn(inputLine, mode, true);
    return int.Parse(firstNumber + lastNumber);
  }

  private string FirstNumberIn(string input, Mode mode, bool reversed)
  {
    var wordsDictionary = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    if (reversed)
    {
      input = Reverse(input);
      wordsDictionary = wordsDictionary.Select(Reverse).ToArray();
    }

    for (int inputCursor = 0; inputCursor < input.Length; inputCursor++)
    {
      char c = input[inputCursor];
      if (int.TryParse(c.ToString(), out _))
        return c.ToString();

      if (mode == Mode.ONLY_NUMBERS)
        continue;

      var substring = input.Substring(inputCursor);
      for (int wordsCursor = 0; wordsCursor < wordsDictionary.Length; wordsCursor++)
      {
        var currentWord = wordsDictionary[wordsCursor];
        if (substring.StartsWith(currentWord))
          return (wordsCursor + 1).ToString();
      }

    }

    throw new Exception("Cannot find number in: " + input);
  }

  private string Reverse(string value)
  {
    return new string(value.ToCharArray().Reverse().ToArray());
  }

}