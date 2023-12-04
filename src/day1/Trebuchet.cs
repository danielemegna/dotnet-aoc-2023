namespace aoc2023;

public class Trebuchet
{
  public int SumOfCalibrationValuesFor(string[] inputLines)
  {
    return inputLines.Select(CalibrationValueFromRow).Sum();
  }

  private int CalibrationValueFromRow(string inputLine)
  {
    var arrayOfCharacters = inputLine.ToCharArray().Select((c) => c.ToString());
    var onlyNumbersCharacters = arrayOfCharacters.Where((c) => int.TryParse(c, out _)).ToArray();
    var valueAsString = onlyNumbersCharacters.First() + onlyNumbersCharacters.Last();
    return int.Parse(valueAsString);
  }
}