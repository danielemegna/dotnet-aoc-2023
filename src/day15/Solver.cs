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
    var operations = firstSingleRow.Split(",").Select(s => LensBoxOperation.BuildFrom(s));

    LensBox[] lensBoxes = Enumerable.Range(0, 256).Select(n => new LensBox()).ToArray();
    foreach (var operation in operations)
    {
      int boxNumber = holidayASCIIStringHelper.HashCodeOf(operation.GetLabel());
      LensBox box = lensBoxes[boxNumber];

      switch (operation)
      {
        case AddLensOperation:
          box.AddLens(
            lensLabel: operation.GetLabel(),
            lensFocalLength: (int)operation.GetFocalLength()!
          );
          break;
        case RemoveLensOperation:
          box.RemoveLensWithLabel(operation.GetLabel());
          break;
      }
    }

    return lensBoxes
      .Select((box, index) => box.FocusingPower(boxNumber: index))
      .Sum();
  }
}
