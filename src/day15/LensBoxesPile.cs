namespace aoc2023.day15;

public class LensBoxesPile
{
  private readonly LensBox[] lensBoxes;

  public LensBoxesPile(int size)
  {
    lensBoxes = Enumerable.Range(0, size).Select(n => new LensBox()).ToArray();
  }

  public void Apply(AddLensOperation operation, int boxNumber)
  {
    LensBox? lensBox = lensBoxes.ElementAtOrDefault(boxNumber);
    if (lensBox == null)
      throw new IndexOutOfRangeException($"Cannot apply operation on box [{boxNumber}], LensBoxesPile size [{this.lensBoxes.Length}]");

    lensBox.AddLens(
      lensLabel: operation.GetLabel(),
      lensFocalLength: (int)operation.GetFocalLength()!
    );
  }

  public void Apply(RemoveLensOperation operation, int boxNumber)
  {
    LensBox? lensBox = lensBoxes.ElementAtOrDefault(boxNumber);
    if (lensBox == null)
      throw new IndexOutOfRangeException($"Cannot apply operation on box [{boxNumber}], LensBoxesPile size [{this.lensBoxes.Length}]");

    lensBox.RemoveLensWithLabel(operation.GetLabel());
  }

  public int TotalFocusingPower()
  {
    return lensBoxes
      .Select((box, index) => box.FocusingPower(boxNumber: index))
      .Sum();
  }

}