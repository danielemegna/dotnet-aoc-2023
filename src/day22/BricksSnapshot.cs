namespace aoc2023.day22;

public class BricksSnapshot
{
  private readonly HashSet<Brick> bricks;

  public BricksSnapshot(IEnumerable<Brick> bricks) => this.bricks = bricks.ToHashSet();
  public BricksSnapshot(params Brick[] bricks) => this.bricks = bricks.ToHashSet();

  public Brick BrickAt(Coordinate coordinate)
  {
    return bricks.FirstOrDefault(
      b => b.IsOccupying(coordinate),
      new NullBrick(coordinate)
    );
  }

  public IReadOnlySet<Brick> BricksAt(IEnumerable<Coordinate> coordinate)
  {
    return coordinate
      .Select(BrickAt)
      .Where(b => b.GetType() != typeof(NullBrick))
      .ToHashSet();
  }

  public void CompleteFall()
  {
    var verticallySortedBricks = bricks.ToList().OrderBy(b => b.StartCoordinate.Z);

    foreach (var brick in verticallySortedBricks)
    {
      var clonedBrick = brick with { };
      while (clonedBrick.StartCoordinate.Z > 1)
      {
        var belowCoordinates = clonedBrick.GetBelowCoordinates();
        if (!AreFree(belowCoordinates)) break;
        clonedBrick = clonedBrick.MoveDown();
      }

      if (clonedBrick.Equals(brick)) continue;

      bricks.Remove(brick);
      bricks.Add(clonedBrick);
    }
  }

  public int CountLoadBearingBricks()
  {
    return bricks.Count(CheckStabilityRemovingBrick);
  }

  public bool CheckStabilityRemovingBrick(Brick brickToRemove)
  {
    var aboveCoordinates = brickToRemove.GetAboveCoordinates();
    var aboveBricks = BricksAt(aboveCoordinates);

    BricksSnapshot clone = new(bricks);
    clone.bricks.Remove(brickToRemove);
    var isAnyBricksFalling = aboveBricks.Any(b => clone.AreFree(b.GetBelowCoordinates()));
    return !isAnyBricksFalling;
  }

  private bool AreFree(IEnumerable<Coordinate> coordinates) => coordinates.All(IsFree);
  private bool IsFree(Coordinate coordinate) => BrickAt(coordinate).GetType() == typeof(NullBrick);

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(BricksSnapshot)) return false;
    BricksSnapshot otherCasted = (BricksSnapshot)other;

    return bricks.SetEquals(otherCasted.bricks);
  }

  public override int GetHashCode()
  {
    return Convert.ToInt32(bricks.Select(b => b.GetHashCode()).Average());
  }

}
