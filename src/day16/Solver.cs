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
    var maxEnergizedTilesForTopRow = Enumerable.Range(0, inputLines.Length)
      .AsParallel()
      .Select(index =>
      {
        Beam initialBeam = new Beam(
          Coordinate: new Coordinate(X: index, Y: 0),
          Direction: BeamDirection.DOWN
        );
        return EnergizedTilesTotalCountFor(inputLines, initialBeam);
      }).Max();

    var maxEnergizedTilesForBottomRow = Enumerable.Range(0, inputLines.Length)
      .AsParallel()
      .Select(index =>
      {
        Beam initialBeam = new Beam(
          Coordinate: new Coordinate(X: index, Y: inputLines.Length - 1),
          Direction: BeamDirection.UP
        );
        return EnergizedTilesTotalCountFor(inputLines, initialBeam);
      }).Max();

    var maxEnergizedTilesForLeftBorder = Enumerable.Range(0, inputLines.Length)
      .AsParallel()
      .Select(index =>
      {
        Beam initialBeam = new Beam(
          Coordinate: new Coordinate(X: 0, Y: index),
          Direction: BeamDirection.RIGHT
        );
        return EnergizedTilesTotalCountFor(inputLines, initialBeam);
      }).Max();

    var maxEnergizedTilesForRightBorder = Enumerable.Range(0, inputLines.Length)
      .AsParallel()
      .Select(index =>
      {
        Beam initialBeam = new Beam(
          Coordinate: new Coordinate(X: inputLines.Length - 1, Y: index),
          Direction: BeamDirection.LEFT
        );
        return EnergizedTilesTotalCountFor(inputLines, initialBeam);
      }).Max();

    return ((int[])[
      maxEnergizedTilesForTopRow,
      maxEnergizedTilesForBottomRow,
      maxEnergizedTilesForLeftBorder,
      maxEnergizedTilesForRightBorder
    ]).Max();
  }

  private int EnergizedTilesTotalCountFor(string[] mapInputLines, Beam initialBeam)
  {
    var contraptionMap = ContraptionMap.From(mapInputLines, initialBeam);

    while (contraptionMap.GetExistingBeams().Count > 0)
      contraptionMap.MoveNextAllBeams();

    return contraptionMap.EnergizedTilesCount();
  }

}
