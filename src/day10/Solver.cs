namespace aoc2023.day10;

class Solver
{
  private readonly ISet<Coordinate> visitedCoordinates = new HashSet<Coordinate>();

  public int FarthestPointFromStartDistance(string[] inputLines)
  {
    var gardenMap = GardenMap.From(inputLines);
    int stepsCounter = 0;

    var start = gardenMap.StartingPosition();
    var (left, right) = gardenMap.ConnectionsFor(start);
    visitedCoordinates.Add(start);
    visitedCoordinates.Add(left);
    visitedCoordinates.Add(right);
    stepsCounter++;

    while (left != right)
    {
      left = NotVisitedConnectionFor(left, gardenMap);
      right = NotVisitedConnectionFor(right, gardenMap);

      visitedCoordinates.Add(left);
      visitedCoordinates.Add(right);
      stepsCounter++;
    }

    return stepsCounter;
  }

  private Coordinate NotVisitedConnectionFor(Coordinate coordinate, GardenMap gardenMap)
  {
    var (left, right) = gardenMap.ConnectionsFor(coordinate);

    if (visitedCoordinates.Contains(left))
      return right;

    return left;
  }

}
