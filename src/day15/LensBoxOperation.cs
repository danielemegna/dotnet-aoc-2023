namespace aoc2023.day15;

public abstract class LensBoxOperation
{
  public static LensBoxOperation BuildFrom(string stringValue)
  {
    if (stringValue.EndsWith('-'))
    {
      string operationLabel = stringValue[..^1];
      return new RemoveLensOperation(operationLabel);
    }

    string[] parts = stringValue.Split("=");
    return new AddLensOperation(
      Label: parts[0],
      FocalLength: int.Parse(parts[1])
    );
  }

  abstract public string GetLabel();
  abstract public int? GetFocalLength();
  abstract public void ApplyOn(LensBox lensBox);
}

public class AddLensOperation(string Label, int FocalLength) : LensBoxOperation
{
  public override string GetLabel() => Label;
  public override int? GetFocalLength() => FocalLength;
  public override void ApplyOn(LensBox lensBox) => lensBox.AddLens(Label, FocalLength);
}

public class RemoveLensOperation(string Label) : LensBoxOperation
{
  public override string GetLabel() => Label;
  public override int? GetFocalLength() => null;
  public override void ApplyOn(LensBox lensBox) => lensBox.RemoveLensWithLabel(Label);
}
