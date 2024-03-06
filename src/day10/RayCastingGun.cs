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

    var (
      (xMinimumValue, yMinimumValue),
      (xMaximumValue, yMaximumValue)
    ) = gardenMap.LoopBoundaries;

    for (int x = xMinimumValue; x <= xMaximumValue; x++)
    {
      for (int y = yMinimumValue; y <= yMaximumValue; y++)
      {
        Coordinate currentCoordinate = new(x, y);
        var isInsideTheLoop = ScanCoordinate(currentCoordinate, yMinimumValue);
        if (isInsideTheLoop)
          result.Add(currentCoordinate);
      }
    }

    return result;
  }

  private bool ScanCoordinate(Coordinate coordinate, int yMinimumValue)
  {
    if (gardenMap.IsPartOfTheLoop(coordinate))
      return false;

    int boundariesCount = 0;
    char? previousOpenValue = null;
    for (int y = yMinimumValue; y < coordinate.Y; y++)
    {
      Coordinate currentCoordinate = new(coordinate.X, y);

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
