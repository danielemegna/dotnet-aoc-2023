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
}

public class AddLensOperation(string Label, int FocalLength) : LensBoxOperation
{
  public override string GetLabel() => Label;
  public override int? GetFocalLength() => FocalLength;
}

public class RemoveLensOperation(string Label) : LensBoxOperation
{
  public override string GetLabel() => Label;
  public override int? GetFocalLength() => null;
}
