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

        var currentCoordinate = new Coordinate(X: x, Y: y);
        switch (mapCharacter)
        {
          case '\\':
            mirrors.Add(currentCoordinate, Mirror.NORD_WEST__SOUTH_EAST);
            continue;
          case '/':
            mirrors.Add(currentCoordinate, Mirror.SOUTH_WEST__NORTH_EAST);
            continue;
        }
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

    if (!mirrors.ContainsKey(nextCoordinate))
    {
      this.existingBeams[nextCoordinate] = beamDirection;
      return;
    }

    var hittingMirror = mirrors[nextCoordinate];
    BeamDirection newBeamDirection = default;
    switch (hittingMirror)
    {
      case Mirror.NORD_WEST__SOUTH_EAST:
        if (beamDirection == BeamDirection.RIGHT)
        {
          nextCoordinate = nextCoordinate with { Y = nextCoordinate.Y + 1 };
          newBeamDirection = BeamDirection.DOWN;
        }
        else
        {
          nextCoordinate = nextCoordinate with { X = nextCoordinate.X + 1 };
          newBeamDirection = BeamDirection.RIGHT;
        }
        break;
      case Mirror.SOUTH_WEST__NORTH_EAST:
        nextCoordinate = nextCoordinate with { Y = nextCoordinate.Y - 1 };
        newBeamDirection = BeamDirection.UP;
        break;
    }


    this.existingBeams[nextCoordinate] = newBeamDirection;

  }

  public enum BeamDirection { RIGHT, DOWN, UP }
  public enum Mirror { NORD_WEST__SOUTH_EAST, SOUTH_WEST__NORTH_EAST }
}
