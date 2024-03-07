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

  public bool IsInsideTheLoop(Coordinate coordinate)
  {
    return insideTheLoopCoordinates.Contains(coordinate);
  }

  public int InsideTheLoopCoordinateCount()
  {
    return insideTheLoopCoordinates.Count;
  }

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

    if(gardenMap.LoopStartCoordinate.X == coordinateToScan.X)
      return HorizontalRayShot(coordinateToScan, northWestBoundary.X);

    return VerticalRayShot(coordinateToScan, northWestBoundary.Y);
  }

  private bool HorizontalRayShot(Coordinate coordinateToScan, int xMinimumValue)
  {
    int boundariesCount = 0;
    char? previousOpenValue = null;
    for (int x = xMinimumValue; x < coordinateToScan.X; x++)
    {
      Coordinate currentCoordinate = new(x, coordinateToScan.Y);

      if (gardenMap.IsPartOfTheLoop(currentCoordinate))
      {
        char currentCoordinateValue = gardenMap.MapValueAt(currentCoordinate);
        if (currentCoordinateValue == '|')
          boundariesCount++;

        if (currentCoordinateValue == '-')
          continue;

        if (currentCoordinateValue == 'F' || currentCoordinateValue == 'L')
        {
          previousOpenValue = currentCoordinateValue;
          continue;
        }

        if (currentCoordinateValue == 'J' && previousOpenValue == 'F')
          boundariesCount++;

        if (currentCoordinateValue == '7' && previousOpenValue == 'L')
          boundariesCount++;

      }
    }

    return boundariesCount % 2 == 1;
  }

  private bool VerticalRayShot(Coordinate coordinateToScan, int yMinimumValue)
  {
    int boundariesCount = 0;
    char? previousOpenValue = null;
    for (int y = yMinimumValue; y < coordinateToScan.Y; y++)
    {
      Coordinate currentCoordinate = new(coordinateToScan.X, y);

      if (gardenMap.IsPartOfTheLoop(currentCoordinate))
      {
        char currentCoordinateValue = gardenMap.MapValueAt(currentCoordinate);
        if (currentCoordinateValue == '-')
          boundariesCount++;

        if (currentCoordinateValue == '|')
          continue;

        if (currentCoordinateValue == 'F' || currentCoordinateValue == '7')
        {
          previousOpenValue = currentCoordinateValue;
          continue;
        }

        if (currentCoordinateValue == 'J' && previousOpenValue == 'F')
          boundariesCount++;

        if (currentCoordinateValue == 'L' && previousOpenValue == '7')
          boundariesCount++;

      }
    }

    return boundariesCount % 2 == 1;
  }
}
