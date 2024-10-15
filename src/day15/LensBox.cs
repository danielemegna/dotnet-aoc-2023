namespace aoc2023.day15;

class LensBox
{
  private readonly List<Lens> lenses = [];

  public void AddLens(string lensLabel, int lensFocalLength)
  {
    var found = lenses.Find(l => l.Label == lensLabel);
    if (found != null)
    {
      found.UpdateFocalLenght(lensFocalLength);
      return;
    }

    this.lenses.Add(new Lens(lensLabel, lensFocalLength));
  }

  public int FocusingPower(int boxNumber)
  {
    if (this.lenses.Count == 0)
      return 0;

    int boxNumberCoefficient = 1 + boxNumber;
    return this.lenses.Select((lens, index) =>
       boxNumberCoefficient * (index + 1) * lens.FocalLength
    ).Sum();
  }

  public void RemoveLensWithLabel(string labelOfLensToRemove)
  {
    lenses.RemoveAll(l => l.Label == labelOfLensToRemove);
  }
}
