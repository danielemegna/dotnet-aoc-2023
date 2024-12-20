namespace aoc2023.day16;

public class ContraptionMap
{
  private readonly int size;
  private readonly Dictionary<Coordinate, Mirror> mirrors;
  private readonly Dictionary<Coordinate, Splitter> splitters;
  private readonly HashSet<Beam> existingBeams;
  private readonly HashSet<Beam> beamsHistoryRepository;

  public static ContraptionMap From(string[] mapRows, Beam initialBeam)
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
      initialBeam: initialBeam
    );
  }

  private ContraptionMap(
      int size,
      Dictionary<Coordinate, Mirror> mirrors,
      Dictionary<Coordinate, Splitter> splitters,
      Beam initialBeam
  )
  {
    this.size = size;
    this.mirrors = mirrors;
    this.splitters = splitters;
    this.existingBeams = [];
    this.beamsHistoryRepository = [];
    InsertBeamInMap(initialBeam);
  }

  public HashSet<Beam> GetExistingBeams()
  {
    return this.existingBeams;
  }

  public int EnergizedTilesCount()
  {
    return this.beamsHistoryRepository.DistinctBy(b => b.Coordinate).Count();
  }

  public void MoveNextAllBeams()
  {
    if (this.existingBeams.Count == 0)
      return;

    List<Beam> existingBeamsClone = new(this.existingBeams);
    foreach (var beam in existingBeamsClone)
    {
      this.existingBeams.Remove(beam);
      var beamToInsert = beam.StepForward();
      InsertBeamInMap(beamToInsert);
    }
  }

  private void InsertBeamInMap(Coordinate beamCoordinate, BeamDirection beamDirection)
    => InsertBeamInMap(new Beam(beamCoordinate, beamDirection));

  private void InsertBeamInMap(Beam beamToInsert)
  {
    if (IsOutOfMapBounds(beamToInsert.Coordinate))
      return;

    if (this.beamsHistoryRepository.Contains(beamToInsert))
      return;

    this.beamsHistoryRepository.Add(beamToInsert);

    if (IsHittingAMirror(beamToInsert.Coordinate))
    {
      HandleMirrorHit(beamToInsert);
      return;
    }

    if (IsHittingASplitter(beamToInsert.Coordinate))
    {
      HandleSplitterHit(beamToInsert);
      return;
    }

    this.existingBeams.Add(beamToInsert);
  }

  private bool IsOutOfMapBounds(Coordinate c) =>
    c.X < 0 || c.Y < 0 || c.X >= this.size || c.Y >= this.size;

  private bool IsHittingAMirror(Coordinate c) => mirrors.ContainsKey(c);
  private bool IsHittingASplitter(Coordinate c) => splitters.ContainsKey(c);

  private void HandleMirrorHit(Beam beam)
  {
    var hittingMirror = mirrors[beam.Coordinate];
    var newBeamDirection = NewBeamDirectionFor(beam.Direction, hittingMirror);
    var beamWithNewDirection = beam with { Direction = newBeamDirection };
    var beamToInsert = beamWithNewDirection.StepForward();

    // deliberately not handling infite loop on adjacent mirrors (is it possibile?)
    InsertBeamInMap(beamToInsert);
  }

  private void HandleSplitterHit(Beam beam)
  {
    var hittingSplitter = splitters[beam.Coordinate];
    if (
      hittingSplitter == Splitter.NORTH_SOUTH &&
      (beam.Direction == BeamDirection.RIGHT || beam.Direction == BeamDirection.LEFT)
    )
    {
      InsertBeamInMap(beam.Coordinate with { Y = beam.Coordinate.Y - 1 }, BeamDirection.UP);
      InsertBeamInMap(beam.Coordinate with { Y = beam.Coordinate.Y + 1 }, BeamDirection.DOWN);
      return;
    }

    if (
      hittingSplitter == Splitter.WEST_EAST &&
      (beam.Direction == BeamDirection.DOWN || beam.Direction == BeamDirection.UP)
    )
    {
      InsertBeamInMap(beam.Coordinate with { X = beam.Coordinate.X - 1 }, BeamDirection.LEFT);
      InsertBeamInMap(beam.Coordinate with { X = beam.Coordinate.X + 1 }, BeamDirection.RIGHT);
      return;
    }

    var beamToInsert = beam.StepForward();
    InsertBeamInMap(beamToInsert);
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

  public enum Mirror { NORD_WEST__SOUTH_EAST, SOUTH_WEST__NORTH_EAST }
  public enum Splitter { WEST_EAST, NORTH_SOUTH }
}
