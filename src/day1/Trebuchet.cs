namespace aoc2023;

public class Trebuchet
{
  public int SumOfCalibrationValuesFor(string input)
  {
    string[] lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    return lines.Select(CalibrationValueFromRow).Sum();
  }

  private int CalibrationValueFromRow(string row)
  {
    var onlyNumbersArray = row
      .ToCharArray()
      .Select((c) => c.ToString())
      .Where((c) => int.TryParse(c, out _))
      .ToArray();
    return int.Parse(onlyNumbersArray.First() + onlyNumbersArray.Last());
  }
}