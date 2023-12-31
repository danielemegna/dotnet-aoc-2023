using System.IO.Compression;

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
    var verticallySortedBrick = Bricks.ToList().OrderBy(b => b.StartCoordinate.Z);

    foreach (var brick in verticallySortedBrick)
    {
      var movedBrick = new Brick(brick.StartCoordinate, brick.EndCoordinate);
      while (movedBrick.StartCoordinate.Z > 1)
      {
        var belowCoordinates = movedBrick.GetBelowCoordinates();
        if (belowCoordinates.Any(IsOccupied)) break;
        movedBrick = movedBrick.MoveDown();
      }

      if (movedBrick.Equals(brick)) continue;

      Bricks.Remove(brick);
      Bricks.Add(movedBrick);
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
