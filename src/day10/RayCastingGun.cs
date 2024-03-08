namespace aoc2023.day10;

public class RayCastingGun
{
  private readonly GardenMap gardenMap;
  private readonly ISet<Coordinate> insideTheLoopCoordinates;

  public RayCastingGun(GardenMap gardenMap)
  {
    this.gardenMap = gardenMap;
    this.insideTheLoopCoordinates = ScanInsideTheLoopCoordinates();
  }

  public bool IsInsideTheLoop(Coordinate coordinate) =>
    insideTheLoopCoordinates.Contains(coordinate);

  public int InsideTheLoopCoordinateCount() =>
    insideTheLoopCoordinates.Count;

  private ISet<Coordinate> ScanInsideTheLoopCoordinates()
  {
    var (northWestLoopBoundary, southEastLoopBoundary) = gardenMap.LoopBoundaries;
    var scanAreaCoordinates = Range(northWestLoopBoundary.X, southEastLoopBoundary.X)
      .SelectMany(x =>
        Range(northWestLoopBoundary.Y, southEastLoopBoundary.Y)
          .Select(y => new Coordinate(x, y))
      );

    return scanAreaCoordinates
      .Where(CheckIfInsideTheLoopWithRayCasting)
      .ToHashSet();
  }

  private bool CheckIfInsideTheLoopWithRayCasting(Coordinate coordinateToScan)
  {
    if (gardenMap.IsPartOfTheLoop(coordinateToScan))
      return false;

    var castConfiguration = RayCastingConfiguration.GetFor(coordinateToScan, gardenMap);
    var castingStartCoordinate = castConfiguration.CastingStartCoordinate();

    int boundariesCount = 0;
    char? openingCrossingvalue = null;
    for (
      var currentCoordinate = castingStartCoordinate;
      currentCoordinate != coordinateToScan;
      currentCoordinate = castConfiguration.GetNextCoordinate(currentCoordinate)
    )
    {
      if (!gardenMap.IsPartOfTheLoop(currentCoordinate))
        continue;

      char currentCoordinateValue = gardenMap.MapValueAt(currentCoordinate);

      if (castConfiguration.IsCrossingLoopBoundaryValue(currentCoordinateValue))
        boundariesCount++;

      if (castConfiguration.IsOpeningACrossing(currentCoordinateValue))
      {
        openingCrossingvalue = currentCoordinateValue;
        continue;
      }

      if (castConfiguration.IsCompletingACrossing(openingCrossingvalue, currentCoordinateValue))
        boundariesCount++;
    }

    return boundariesCount % 2 == 1;
  }

  private static IEnumerable<int> Range(int from, int to)
    => Enumerable.Range(from, to - from + 1);
}
