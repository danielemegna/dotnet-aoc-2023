namespace aoc2023.day16;

public class ContraptionMap
{
  private readonly int size;
  private readonly Dictionary<Coordinate, Mirror> mirrors;
  private readonly Dictionary<Coordinate, BeamDirection> existingBeams;

  public static ContraptionMap From(string[] mapRows)
  {
    Dictionary<Coordinate, Mirror> mirrors = [];
    for (int y = 0; y < mapRows.Length; y++)
    {
      var row = mapRows[y];
      for (int x = 0; x < row.Length; x++)
      {
        var mapCharacter = row[x];
        if (mapCharacter == '.')
          continue;

        mirrors.Add(new Coordinate(X: x, Y: y), Mirror.NORD_WEST__SOUTH_EAST);
      }
    }

    return new ContraptionMap(
      size: mapRows.Length,
      mirrors: mirrors
    );
  }

  public ContraptionMap(int size, Dictionary<Coordinate, Mirror> mirrors)
  {
    this.size = size;
    this.mirrors = mirrors;
    this.existingBeams = new()
    {
      [new Coordinate(X: 0, Y: 0)] = BeamDirection.RIGHT
    };
  }

  public Dictionary<Coordinate, BeamDirection> GetExistingBeams()
  {
    return this.existingBeams;
  }

  public void MoveNextAllBeams()
  {
    if (this.existingBeams.Count == 0)
      return;

    Coordinate beamCoordinate = this.existingBeams.First().Key;
    BeamDirection beamDirection = this.existingBeams.First().Value;

    this.existingBeams.Remove(beamCoordinate);

    var nextCoordinate = beamCoordinate.Next(beamDirection);
    if (nextCoordinate.X == this.size || nextCoordinate.Y == this.size)
      return;

    if (mirrors.ContainsKey(nextCoordinate))
    {
      if (beamDirection == BeamDirection.RIGHT)
      {
        nextCoordinate = nextCoordinate with { Y = nextCoordinate.Y + 1 };
        beamDirection = BeamDirection.DOWN;
      }
      else
      {
        nextCoordinate = nextCoordinate with { X = nextCoordinate.X + 1 };
        beamDirection = BeamDirection.RIGHT;
      }
    }

    this.existingBeams[nextCoordinate] = beamDirection;
  }

  public enum BeamDirection { RIGHT, DOWN }
  public enum Mirror { NORD_WEST__SOUTH_EAST }
}
