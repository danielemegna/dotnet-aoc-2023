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
    var result = new HashSet<Coordinate>();

    var (northWestBoundary, southEastBoundary) = gardenMap.LoopBoundaries;

    for (int x = northWestBoundary.X; x <= southEastBoundary.X; x++)
    {
      for (int y = northWestBoundary.Y; y <= southEastBoundary.Y; y++)
      {
        Coordinate currentCoordinate = new(x, y);
        var isInsideTheLoop = ScanCoordinate(currentCoordinate, northWestBoundary);
        if (isInsideTheLoop)
          result.Add(currentCoordinate);
      }
    }

    return result;
  }

  private bool ScanCoordinate(Coordinate coordinateToScan, Coordinate northWestBoundary)
  {
    if (gardenMap.IsPartOfTheLoop(coordinateToScan))
      return false;

    var doVerticalRayScan = gardenMap.LoopStartCoordinate.X != coordinateToScan.X;

    char crossingLoopValue = doVerticalRayScan ? '-' : '|';
    (char, char) firstPair = ('F', 'J');
    (char, char) secondPair = doVerticalRayScan ? ('7', 'L') : ('L', '7');
    Coordinate startCoordinate = doVerticalRayScan ?
      new(coordinateToScan.X, northWestBoundary.Y) :
      new(northWestBoundary.X, coordinateToScan.Y);

    int boundariesCount = 0;
    char? previousOpenValue = null;
    for (
      var currentCoordinate = startCoordinate;
      currentCoordinate != coordinateToScan;
      currentCoordinate = doVerticalRayScan ?
        currentCoordinate with { Y = currentCoordinate.Y + 1 } :
        currentCoordinate with { X = currentCoordinate.X + 1 }
    )
    {
      if (!gardenMap.IsPartOfTheLoop(currentCoordinate))
        continue;

      char currentCoordinateValue = gardenMap.MapValueAt(currentCoordinate);

      if (currentCoordinateValue == crossingLoopValue)
        boundariesCount++;

      if (currentCoordinateValue == firstPair.Item1 || currentCoordinateValue == secondPair.Item1)
      {
        previousOpenValue = currentCoordinateValue;
        continue;
      }

      if (
        previousOpenValue == firstPair.Item1 && currentCoordinateValue == firstPair.Item2 ||
        previousOpenValue == secondPair.Item1 && currentCoordinateValue == secondPair.Item2
      )
      {
        boundariesCount++;
      }

    }

    return boundariesCount % 2 == 1;
  }
}
