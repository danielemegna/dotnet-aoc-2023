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
    var clonedBricks = new HashSet<Brick>(Bricks);
    foreach (var brick in clonedBricks)
    {
      if (brick.StartCoordinate.Z == 1) continue;

      var newZValue = brick.StartCoordinate.Z;
      while (
        !IsOccupied(brick.StartCoordinate with { Z = newZValue - 1 }) &&
        !IsOccupied(brick.EndCoordinate with { Z = newZValue - 1 }) &&
        newZValue > 1
      ) {
        newZValue--;
      }

      var newBrick = new Brick(
        brick.StartCoordinate with { Z = newZValue },
        brick.EndCoordinate with { Z = newZValue }
      );

      Bricks.Remove(brick);
      Bricks.Add(newBrick);
    }
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
