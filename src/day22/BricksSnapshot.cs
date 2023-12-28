namespace aoc2023.day22;

public class BricksSnapshot
{
  public ISet<Brick> Bricks { get; }

  public BricksSnapshot(params Brick[] bricks)
  {
    Bricks = bricks.ToHashSet();
  }

  public Brick BrickAt(Coordinate coordinate)
  {
    return Bricks.FirstOrDefault(
      b => b.IsOccupying(coordinate),
      new NullBrick(coordinate)
    );
  }

  public void CompleteFall()
  {
    Brick b = Bricks.First();
    if (b.StartCoordinate.Z == 1) return;

    var newZValue = b.StartCoordinate.Z;
    while (
      !IsOccupied(b.StartCoordinate with { Z = newZValue - 1 })
      && newZValue > 1
    ) {
      newZValue--;
    }

    var newBrick = new Brick(
      b.StartCoordinate with { Z = newZValue },
      b.EndCoordinate with { Z = newZValue }
    );

    Bricks.Remove(b);
    Bricks.Add(newBrick);
  }

  private bool IsOccupied(Coordinate coordinate)
  {
    return BrickAt(coordinate).GetType() != typeof(NullBrick);
  }

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(BricksSnapshot)) return false;
    BricksSnapshot otherCasted = (BricksSnapshot)other;

    return Bricks.SetEquals(otherCasted.Bricks);
  }

  public override int GetHashCode()
  {
    return Convert.ToInt32(Bricks.Select(b => b.GetHashCode()).Average());
  }

}
