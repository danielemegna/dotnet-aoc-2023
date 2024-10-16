namespace aoc2023.day15;

public class LensBoxesPile
{
  private readonly LensBox[] lensBoxes;

  public LensBoxesPile(int size)
  {
    lensBoxes = Enumerable.Range(0, size).Select(n => new LensBox()).ToArray();
  }

  public void Apply(LensBoxOperation operation, int boxNumber)
  {
    LensBox? lensBox = lensBoxes.ElementAtOrDefault(boxNumber);
    if (lensBox == null)
    {
      var errorMessage = $"Cannot apply operation on box [{boxNumber}], LensBoxesPile size [{this.lensBoxes.Length}]";
      throw new IndexOutOfRangeException(errorMessage);
    }

    switch (operation)
    {
      case AddLensOperation:
        lensBox.AddLens(
          lensLabel: operation.GetLabel(),
          lensFocalLength: (int)operation.GetFocalLength()!
        );
        break;
      case RemoveLensOperation removeOperation:
        lensBox.RemoveLensWithLabel(operation.GetLabel());
        break;
    }
  }

  public int TotalFocusingPower()
  {
    return lensBoxes
      .Select((box, index) => box.FocusingPower(boxNumber: index))
      .Sum();
  }

}