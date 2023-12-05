namespace aoc2023;

public class Trebuchet
{
  public int SumOfCalibrationValuesFor(string[] inputLines, bool useSpelledNumbers = false)
  {
    return inputLines.Select((line) => CalibrationValueFromRow(line, useSpelledNumbers)).Sum();
  }

  public int CalibrationValueFromRow(string inputLine, bool useSpelledNumbers = false)
  {
    string firstNumber = FirstNumberIn(inputLine, useSpelledNumbers, false);
    string lastNumber = FirstNumberIn(inputLine, useSpelledNumbers, true);
    return int.Parse(firstNumber + lastNumber);
  }

  public string FirstNumberIn(string input, bool useSpelledNumbers, bool reversed)
  {
    var wordsDictionary = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    if (reversed) {
      input = Reverse(input);
      wordsDictionary = wordsDictionary.Select(Reverse).ToArray();
    }

    for (int inputCursor = 0; inputCursor < input.Length; inputCursor++)
    {
      char c = input[inputCursor];
      if (int.TryParse(c.ToString(), out _))
        return c.ToString();

      if (!useSpelledNumbers)
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