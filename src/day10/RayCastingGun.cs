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
      .Where(c => IsInsideTheLoop(c, northWestLoopBoundary))
      .ToHashSet();
  }

  private bool IsInsideTheLoop(Coordinate coordinateToScan, Coordinate northWestLoopBoundary)
  {
    if (gardenMap.IsPartOfTheLoop(coordinateToScan))
      return false;

    var doVerticalRayScan = gardenMap.LoopStartCoordinate.X != coordinateToScan.X;

    char crossingLoopValue = doVerticalRayScan ? '-' : '|';
    (char, char) firstPair = ('F', 'J');
    (char, char) secondPair = doVerticalRayScan ? ('7', 'L') : ('L', '7');
    Coordinate startCoordinate = doVerticalRayScan ?
      new(coordinateToScan.X, northWestLoopBoundary.Y) :
      new(northWestLoopBoundary.X, coordinateToScan.Y);

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

  private static IEnumerable<int> Range(int from, int to)
    => Enumerable.Range(from, to - from + 1);
}
