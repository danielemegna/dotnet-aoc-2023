namespace aoc2023.day16;

public class Solver
{
  public int EnergizedTilesTotalCountFor(string[] inputLines)
  {
    var contraptionMap = ContraptionMap.From(inputLines);

    while(contraptionMap.GetExistingBeams().Count > 0) {
      contraptionMap.MoveNextAllBeams();
    }

    return contraptionMap.EnergizedTilesCount();
  }

  public int MaximumPossibileEnergizedTilesFor(string[] inputLines)
  {
    throw new NotImplementedException();
  }

}
