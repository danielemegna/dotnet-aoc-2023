namespace aoc2023.day15;

public class LensBoxesPile
{
  private readonly LensBox[] lensBoxes;

  public LensBoxesPile(int size)
  {
    this.lensBoxes = new LensBox[size];
  }

  public void Apply(LensBoxOperation operation, int boxNumber)
  {
    if (boxNumber >= this.lensBoxes.Length)
    {
      var errorMessage = $"Cannot apply operation on box [{boxNumber}], LensBoxesPile size [{this.lensBoxes.Length}]";
      throw new IndexOutOfRangeException(errorMessage);
    }

    LensBox lensBox = LensBoxForBoxNumber(boxNumber);
    operation.ApplyOn(lensBox);
  }

  public int TotalFocusingPower()
  {
    return this.lensBoxes
      .Select((box, index) => box?.FocusingPower(boxNumber: index) ?? 0)
      .Sum();
  }

  private LensBox LensBoxForBoxNumber(int boxNumber)
  {
    LensBox? lensBox = this.lensBoxes.ElementAtOrDefault(boxNumber);
    if (lensBox != null)
      return lensBox;

    var newLensBox = new LensBox();
    this.lensBoxes[boxNumber] = newLensBox;
    return newLensBox;
  }

}