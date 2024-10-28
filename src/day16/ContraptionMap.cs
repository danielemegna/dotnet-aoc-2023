namespace aoc2023.day16;

public class ContraptionMap
{
  private readonly int size;
  private readonly Dictionary<Coordinate, Mirror> mirrors;
  private readonly Dictionary<Coordinate, BeamDirection> existingBeams;

  public static ContraptionMap From(string[] mapRows)
  {
    return ContraptionMap.From(
      mapRows: mapRows,
      initialBeamCoordinate: new Coordinate(X: 0, Y: 0),
      initialBeamDirection: BeamDirection.RIGHT
    );
  }

  internal static ContraptionMap From(
    string[] mapRows,
    Coordinate initialBeamCoordinate,
    BeamDirection initialBeamDirection
  )
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
      mirrors: mirrors,
      initialBeamCoordinate: initialBeamCoordinate,
      initialBeamDirection: initialBeamDirection
    );
  }

  private ContraptionMap(
      int size,
      Dictionary<Coordinate, Mirror> mirrors,
      Coordinate initialBeamCoordinate,
      BeamDirection initialBeamDirection
  )
  {
    this.size = size;
    this.mirrors = mirrors;
    this.existingBeams = new()
    {
      [initialBeamCoordinate] = initialBeamDirection
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
        switch (beamDirection)
        {
          case BeamDirection.RIGHT:
            newBeamDirection = BeamDirection.DOWN;
            nextCoordinate = nextCoordinate with { Y = nextCoordinate.Y + 1 };
            break;
          case BeamDirection.LEFT:
            newBeamDirection = BeamDirection.UP;
            nextCoordinate = nextCoordinate with { Y = nextCoordinate.Y - 1 };
            break;
          case BeamDirection.DOWN:
            newBeamDirection = BeamDirection.RIGHT;
            nextCoordinate = nextCoordinate with { X = nextCoordinate.X + 1 };
            break;
          case BeamDirection.UP:
            newBeamDirection = BeamDirection.LEFT;
            nextCoordinate = nextCoordinate with { X = nextCoordinate.X - 1 };
            break;
        }
        break;
      case Mirror.SOUTH_WEST__NORTH_EAST:
        switch (beamDirection)
        {
          case BeamDirection.RIGHT:
            newBeamDirection = BeamDirection.UP;
            nextCoordinate = nextCoordinate with { Y = nextCoordinate.Y - 1 };
            break;
          case BeamDirection.DOWN:
            newBeamDirection = BeamDirection.LEFT;
            nextCoordinate = nextCoordinate with { X = nextCoordinate.X - 1 };
            break;
          case BeamDirection.UP:
            newBeamDirection = BeamDirection.RIGHT;
            nextCoordinate = nextCoordinate with { X = nextCoordinate.X + 1 };
            break;
          case BeamDirection.LEFT:
            newBeamDirection = BeamDirection.DOWN;
            nextCoordinate = nextCoordinate with { Y = nextCoordinate.Y + 1 };
            break;
        }
        break;
    }

    this.existingBeams[nextCoordinate] = newBeamDirection;

  }

  public enum BeamDirection { RIGHT, DOWN, UP, LEFT }
  public enum Mirror { NORD_WEST__SOUTH_EAST, SOUTH_WEST__NORTH_EAST }
}
