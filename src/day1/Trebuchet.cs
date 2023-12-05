namespace aoc2023;

public class Trebuchet
{
  public int SumOfCalibrationValuesFor(string[] inputLines, bool useSpelledNumbers = false)
  {
    return inputLines.Select((line) => CalibrationValueFromRow(line, useSpelledNumbers)).Sum();
  }

  public int CalibrationValueFromRow(string inputLine, bool useSpelledNumbers = false)
  {
    if (useSpelledNumbers)
    {
      var dictionary = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
      for (int i = 0; i < dictionary.Length; i++)
      {
        inputLine = inputLine.Replace(dictionary[i], (i + 1).ToString());
      }
    }


    var arrayOfCharacters = inputLine.ToCharArray().Select((c) => c.ToString());
    var onlyNumbersCharacters = arrayOfCharacters.Where((c) => int.TryParse(c, out _)).ToArray();
    var valueAsString = onlyNumbersCharacters.First() + onlyNumbersCharacters.Last();
    return int.Parse(valueAsString);
  }
}