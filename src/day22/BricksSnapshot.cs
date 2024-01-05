namespace aoc2023.day22;

public class BricksSnapshot
{
  private readonly Dictionary<int, HashSet<Brick>> bricksByZValue;

  public BricksSnapshot(IEnumerable<Brick> bricks)
  {
    this.bricksByZValue = [];
    foreach (var brick in bricks)
      this.AddBrick(brick);
  }

  public Brick BrickAt(Coordinate coordinate)
  {
    var found = bricksByZValue
      .GetValueOrDefault(coordinate.Z)?
      .FirstOrDefault(b => b.IsOccupying(coordinate));

    return found ?? new NullBrick(coordinate);
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
    var verticallySortedBricks = AllBricks().OrderBy(b => b.StartCoordinate.Z);

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
      RemoveBrick(brick);
      AddBrick(clonedBrick);
    }
  }

  public int CountSafeToDisintegrateBricks()
  {
    return AllBricks().Count(IsStableRemovingBrick);
  }

  public int CountFallingBricksOnDisintegrates()
  {
    return AllBricks().Sum(CountFallingBricksRemovingBrick);
  }

  internal bool IsStableRemovingBrick(Brick brickToRemove)
  {
    return CountFallingBricksRemovingBrick(brickToRemove) == 0;
  }

  internal int CountFallingBricksRemovingBrick(Brick brickToRemove)
  {
    BricksSnapshot clone = new(AllBricks());
    return CountFallingBricksRemovingBrickWith(clone, brickToRemove);
  }

  private int CountFallingBricksRemovingBrickWith(BricksSnapshot snapshot, Brick brickToRemove)
  {
    snapshot.RemoveBrick(brickToRemove);

    var aboveCoordinates = brickToRemove.GetAboveCoordinates();
    var aboveBricks = snapshot.BricksAt(aboveCoordinates);
    var fallingBricks = aboveBricks.Where(b => snapshot.AreFree(b.GetBelowCoordinates()));

    var fallingBricksCount = fallingBricks.Count();
    if (fallingBricksCount == 0) return 0;
    return fallingBricksCount + fallingBricks.Sum(b => CountFallingBricksRemovingBrickWith(snapshot, b));
  }

  private void AddBrick(Brick brick)
  {
    for (var z = brick.StartCoordinate.Z; z <= brick.EndCoordinate.Z; z++)
    {
      if (!this.bricksByZValue.ContainsKey(z))
        this.bricksByZValue[z] = [];

      this.bricksByZValue[z].Add(brick);
    }
  }

  private void RemoveBrick(Brick brick)
  {
    for (var z = brick.StartCoordinate.Z; z <= brick.EndCoordinate.Z; z++)
    {
      this.bricksByZValue[z].Remove(brick);
    }
  }

  private IEnumerable<Brick> AllBricks()
  {
    return bricksByZValue.SelectMany(kv => kv.Value).Distinct();
  }

  private bool AreFree(IEnumerable<Coordinate> coordinates) => coordinates.All(IsFree);
  private bool IsFree(Coordinate coordinate) => BrickAt(coordinate).GetType() == typeof(NullBrick);

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(BricksSnapshot)) return false;
    var otherCasted = (BricksSnapshot)other;

    var myBricksSet = AllBricks().ToHashSet();
    var otherBricksSet = otherCasted.AllBricks().ToHashSet();
    return myBricksSet.SetEquals(otherBricksSet);
  }

  public override int GetHashCode()
  {
    return Convert.ToInt32(AllBricks().Select(b => b.GetHashCode()).Average());
  }

}
