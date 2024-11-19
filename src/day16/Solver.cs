namespace aoc2023.day16;

public class Solver
{
  public int EnergizedTilesTotalCountFor(string[] inputLines)
  {
    Beam initialBeam = new Beam(
        Coordinate: new Coordinate(X: 0, Y: 0),
        Direction: BeamDirection.RIGHT
    );
    return EnergizedTilesTotalCountFor(inputLines, initialBeam);
  }

  public int MaximumPossibileEnergizedTilesFor(string[] inputLines)
  {
    throw new NotImplementedException();
  }

  private int EnergizedTilesTotalCountFor(string[] mapInputLines, Beam initialBeam)
  {
    var contraptionMap = ContraptionMap.From(mapInputLines, initialBeam);

    while (contraptionMap.GetExistingBeams().Count > 0)
      contraptionMap.MoveNextAllBeams();

    return contraptionMap.EnergizedTilesCount();
  }

}
