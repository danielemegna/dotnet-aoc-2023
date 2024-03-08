using aoc2023.day10;

interface RayCastingConfiguration
{
  public static RayCastingConfiguration GetFor(Coordinate coordinateToScan, GardenMap gardenMap)
  {
    var (northWestLoopBoundary, _) = gardenMap.LoopBoundaries;
    if (gardenMap.LoopStartCoordinate.X != coordinateToScan.X)
      return new VerticalRayCastingConfiguration(coordinateToScan, northWestLoopBoundary);

    return new HorizontalRayCastingConfiguration(coordinateToScan, northWestLoopBoundary);
  }

  bool IsCrossingLoopBoundaryValue(char value);
  Coordinate CastingStartCoordinate();
  Coordinate GetNextCoordinate(Coordinate currentCoordinate);
  bool IsOpeningACrossing(char value);
  bool IsCompletingACrossing(char? openingValue, char currentValue);
}

class VerticalRayCastingConfiguration : RayCastingConfiguration
{
  private readonly Coordinate coordinateToScan;
  private readonly Coordinate northWestLoopBoundary;

  public VerticalRayCastingConfiguration(Coordinate coordinateToScan, Coordinate northWestLoopBoundary)
  {
    this.coordinateToScan = coordinateToScan;
    this.northWestLoopBoundary = northWestLoopBoundary;
  }

  public Coordinate CastingStartCoordinate() => new(coordinateToScan.X, northWestLoopBoundary.Y);
  public bool IsCrossingLoopBoundaryValue(char value) => value == '-';

  public Coordinate GetNextCoordinate(Coordinate currentCoordinate)
    => currentCoordinate with { Y = currentCoordinate.Y + 1 };

  public bool IsOpeningACrossing(char value) => value == 'F' || value == '7';

  public bool IsCompletingACrossing(char? openingValue, char currentValue) =>
    openingValue == 'F' && currentValue == 'J' ||
    openingValue == '7' && currentValue == 'L';

}

class HorizontalRayCastingConfiguration : RayCastingConfiguration
{
  private readonly Coordinate coordinateToScan;
  private readonly Coordinate northWestLoopBoundary;

  public HorizontalRayCastingConfiguration(Coordinate coordinateToScan, Coordinate northWestLoopBoundary)
  {
    this.coordinateToScan = coordinateToScan;
    this.northWestLoopBoundary = northWestLoopBoundary;
  }

  public Coordinate CastingStartCoordinate() => new(northWestLoopBoundary.X, coordinateToScan.Y);
  public bool IsCrossingLoopBoundaryValue(char value) => value == '|';

  public Coordinate GetNextCoordinate(Coordinate currentCoordinate)
    => currentCoordinate with { X = currentCoordinate.X + 1 };

  public bool IsOpeningACrossing(char value) => value == 'F' || value == 'L';

  public bool IsCompletingACrossing(char? openingValue, char currentValue) =>
    openingValue == 'F' && currentValue == 'J' ||
    openingValue == 'L' && currentValue == '7';
}