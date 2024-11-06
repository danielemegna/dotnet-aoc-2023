namespace aoc2023.day16;

public class ContraptionMap
{
  private readonly int size;
  private readonly Dictionary<Coordinate, Mirror> mirrors;
  private readonly Dictionary<Coordinate, Splitter> splitters;
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
    Dictionary<Coordinate, Splitter> splitters = [];
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
          case '-':
            splitters.Add(currentCoordinate, Splitter.WEST_EAST);
            continue;
          case '|':
            splitters.Add(currentCoordinate, Splitter.NORTH_SOUTH);
            continue;
        }
      }
    }

    return new ContraptionMap(
      size: mapRows.Length,
      mirrors: mirrors,
      splitters: splitters,
      initialBeamCoordinate: initialBeamCoordinate,
      initialBeamDirection: initialBeamDirection
    );
  }

  private ContraptionMap(
      int size,
      Dictionary<Coordinate, Mirror> mirrors,
      Dictionary<Coordinate, Splitter> splitters,
      Coordinate initialBeamCoordinate,
      BeamDirection initialBeamDirection
  )
  {
    this.size = size;
    this.mirrors = mirrors;
    this.splitters = splitters;
    this.existingBeams = [];
    InsertBeamInMap(initialBeamCoordinate, initialBeamDirection);
  }

  public Dictionary<Coordinate, BeamDirection> GetExistingBeams()
  {
    return this.existingBeams;
  }

  public void MoveNextAllBeams()
  {
    if (this.existingBeams.Count == 0)
      return;

    Dictionary<Coordinate, BeamDirection> existingBeamsClone = new(this.existingBeams);
    foreach (var beam in existingBeamsClone)
    {
      Coordinate currentBeamCoordinate = beam.Key;
      BeamDirection currentBeamDirection = beam.Value;

      this.existingBeams.Remove(currentBeamCoordinate);
      var nextCoordinate = currentBeamCoordinate.Next(currentBeamDirection);
      InsertBeamInMap(nextCoordinate, currentBeamDirection);
    }
  }

  private void InsertBeamInMap(Coordinate beamCoordinate, BeamDirection beamDirection)
  {
    if (IsOutOfMapBounds(beamCoordinate))
      return;

    if (IsHittingAMirror(beamCoordinate))
    {
      HandleMirrorHit(beamCoordinate, beamDirection);
      return;
    }

    if (IsHittingASplitter(beamCoordinate))
    {
      HandleSplitterHit(beamCoordinate, beamDirection);
      return;
    }

    this.existingBeams[beamCoordinate] = beamDirection;
  }

  private bool IsOutOfMapBounds(Coordinate c) =>
    c.X < 0 || c.Y < 0 || c.X >= this.size || c.Y >= this.size;

  private bool IsHittingAMirror(Coordinate c) => mirrors.ContainsKey(c);
  private bool IsHittingASplitter(Coordinate c) => splitters.ContainsKey(c);

  private void HandleMirrorHit(Coordinate beamCoordinate, BeamDirection beamDirection)
  {
    var hittingMirror = mirrors[beamCoordinate];
    var newBeamDirection = NewBeamDirectionFor(beamDirection, hittingMirror);
    var newBeamCoordinate = beamCoordinate.Next(newBeamDirection);

    // deliberately not handling infite loop on adjacent mirrors (is it possibile?)
    InsertBeamInMap(newBeamCoordinate, newBeamDirection);
  }

  private void HandleSplitterHit(Coordinate beamCoordinate, BeamDirection beamDirection)
  {
    var hittingSplitter = splitters[beamCoordinate];
    if (
      hittingSplitter == Splitter.NORTH_SOUTH &&
      (beamDirection == BeamDirection.RIGHT || beamDirection == BeamDirection.LEFT)
    )
    {
      InsertBeamInMap(beamCoordinate with { Y = beamCoordinate.Y - 1 }, BeamDirection.UP);
      InsertBeamInMap(beamCoordinate with { Y = beamCoordinate.Y + 1 }, BeamDirection.DOWN);
      return;
    }

    if (
      hittingSplitter == Splitter.WEST_EAST &&
      (beamDirection == BeamDirection.DOWN || beamDirection == BeamDirection.UP)
    )
    {
      InsertBeamInMap(beamCoordinate with { X = beamCoordinate.X - 1 }, BeamDirection.LEFT);
      InsertBeamInMap(beamCoordinate with { X = beamCoordinate.X + 1 }, BeamDirection.RIGHT);
      return;
    }

    var nextBeamCoordinate = beamCoordinate.Next(beamDirection);
    InsertBeamInMap(nextBeamCoordinate, beamDirection);
  }

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
  public enum Splitter { WEST_EAST, NORTH_SOUTH }
}
