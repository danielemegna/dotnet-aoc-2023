namespace aoc2023.day15;

public record Lens
{
  public string Label { get; }
  public int FocalLength { get; private set; }

  public Lens(string Label, int FocalLength)
  {
    this.Label = Label;
    this.FocalLength = FocalLength;
  }

  public void UpdateFocalLenght(int focalLength)
  {
    this.FocalLength = focalLength;
  }
}
