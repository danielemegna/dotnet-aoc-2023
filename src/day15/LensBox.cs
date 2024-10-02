namespace aoc2023.day15;

class LensBox
{
  private readonly List<Lens> lenses = [];

  public void AddLens(Lens lens)
  {
    this.lenses.Add(lens);
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

}

public record Lens(string Label, int FocalLength);
