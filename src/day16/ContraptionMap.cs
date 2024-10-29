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

    Coordinate currentBeamCoordinate = this.existingBeams.First().Key;
    BeamDirection currentBeamDirection = this.existingBeams.First().Value;

    this.existingBeams.Remove(currentBeamCoordinate);
    var nextCoordinate = currentBeamCoordinate.Next(currentBeamDirection);

    if (IsOutOfMapBounds(nextCoordinate))
      return;

    if (!IsHittingAMirror(nextCoordinate))
    {
      this.existingBeams[nextCoordinate] = currentBeamDirection;
      return;
    }

    var hittingMirror = mirrors[nextCoordinate];
    var newBeamDirection = NewBeamDirectionFor(currentBeamDirection, hittingMirror);
    nextCoordinate = nextCoordinate.Next(newBeamDirection);
    if (IsOutOfMapBounds(nextCoordinate))
      return;

    if (!IsHittingAMirror(nextCoordinate))
    {
      this.existingBeams[nextCoordinate] = newBeamDirection;
      return;
    }

    hittingMirror = mirrors[nextCoordinate];
    newBeamDirection = NewBeamDirectionFor(newBeamDirection, hittingMirror);
    nextCoordinate = nextCoordinate.Next(newBeamDirection);
    this.existingBeams[nextCoordinate] = newBeamDirection;
  }

  private bool IsOutOfMapBounds(Coordinate c) => c.X >= this.size || c.Y >= this.size;
  private bool IsHittingAMirror(Coordinate c) => mirrors.ContainsKey(c);

  private BeamDirection NewBeamDirectionFor(BeamDirection beamDirection, Mirror hittingMirror)
  {
    switch (hittingMirror)
    {
      case Mirror.NORD_WEST__SOUTH_EAST:
        switch (beamDirection)
        {
          case BeamDirection.RIGHT: return BeamDirection.DOWN;
          case BeamDirection.DOWN: return BeamDirection.RIGHT;
          case BeamDirection.LEFT: return BeamDirection.UP;
          case BeamDirection.UP: return BeamDirection.LEFT;
        }
        break;
      case Mirror.SOUTH_WEST__NORTH_EAST:
        switch (beamDirection)
        {
          case BeamDirection.RIGHT: return BeamDirection.UP;
          case BeamDirection.DOWN: return BeamDirection.LEFT;
          case BeamDirection.LEFT: return BeamDirection.DOWN;
          case BeamDirection.UP: return BeamDirection.RIGHT;
        }
        break;
    }

    throw new ArgumentException($"Cannot get NewBeamDirection for [${beamDirection}], [${hittingMirror}]");
  }

  public enum BeamDirection { RIGHT, DOWN, UP, LEFT }
  public enum Mirror { NORD_WEST__SOUTH_EAST, SOUTH_WEST__NORTH_EAST }
}
