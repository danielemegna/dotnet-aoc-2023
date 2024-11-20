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
    return Enumerable
      .Range(0, inputLines.Length)
      .AsParallel()
      .Select(index =>
      {
        var topRowBeam = new Beam(
          Coordinate: new Coordinate(X: index, Y: 0),
          Direction: BeamDirection.DOWN
        );
        var rightBorderBeam = new Beam(
          Coordinate: new Coordinate(X: inputLines.Length - 1, Y: index),
          Direction: BeamDirection.LEFT
        );
        var bottomRowBeam = new Beam(
          Coordinate: new Coordinate(X: index, Y: inputLines.Length - 1),
          Direction: BeamDirection.UP
        );
        var leftBorderBeam = new Beam(
          Coordinate: new Coordinate(X: 0, Y: index),
          Direction: BeamDirection.RIGHT
        );

        Beam[] beams = [topRowBeam, rightBorderBeam, bottomRowBeam, leftBorderBeam];
        return beams.Select(initialBeam =>
          EnergizedTilesTotalCountFor(inputLines, initialBeam)
        ).Max();
      }).Max();
  }

  private int EnergizedTilesTotalCountFor(string[] mapInputLines, Beam initialBeam)
  {
    var contraptionMap = ContraptionMap.From(mapInputLines, initialBeam);

    while (contraptionMap.GetExistingBeams().Count > 0)
      contraptionMap.MoveNextAllBeams();

    return contraptionMap.EnergizedTilesCount();
  }

}
