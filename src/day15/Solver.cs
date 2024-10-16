namespace aoc2023.day15;

public class Solver
{
  private HolidayASCIIStringHelper holidayASCIIStringHelper = new HolidayASCIIStringHelper();

  public int SumOfHashAlgorithmResultsFor(string[] input)
  {
    var firstSingleRow = input[0];
    return firstSingleRow.Split(",").Select(s => holidayASCIIStringHelper.HashCodeOf(s)).Sum();
  }

  public int TotalFocusingPowerWith(string[] input)
  {
    var firstSingleRow = input[0];
    var lensBoxesPile = new LensBoxesPile(size: 256);

    firstSingleRow
      .Split(",")
      .Select(operationString => LensBoxOperation.BuildFrom(operationString))
      .ToList()
      .ForEach(operation =>
      {
        int boxNumber = holidayASCIIStringHelper.HashCodeOf(operation.GetLabel());
        lensBoxesPile.Apply(operation, boxNumber);
      });

    return lensBoxesPile.TotalFocusingPower();
  }
}
