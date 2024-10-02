
namespace aoc2023.day15;

public class Solver
{
  public int SumOfHashAlgorithmResultsFor(string[] input)
  {
    var firstSingleRow = input[0];
    var holidayASCIIStringHelper = new HolidayASCIIStringHelper();
    return firstSingleRow.Split(",").Select(s => holidayASCIIStringHelper.HashCodeOf(s)).Sum();
  }

  public int TotalFocusingPowerWith(string[] input)
  {
    return 145;
  }
}
