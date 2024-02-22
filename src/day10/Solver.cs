namespace aoc2023.day10;

class Solver
{
  private readonly ISet<Coordinate> visitedCoordinates = new HashSet<Coordinate>();

  public int FarthestPointFromStartDistance(string[] inputLines)
  {
    var gardenMap = GardenMap.From(inputLines);
    var start = gardenMap.StartingPosition();
    int stepsCounter = 0;

    var (left, right) = gardenMap.ConnectionsFor(start);
    visitedCoordinates.Add(left!);
    visitedCoordinates.Add(right!);
    stepsCounter++;

    while (left != right)
    {
      left = NotVisitedConnectionFor(left!, gardenMap);
      right = NotVisitedConnectionFor(right!, gardenMap);

      visitedCoordinates.Add(left!);
      visitedCoordinates.Add(right!);
      stepsCounter++;
    }

    return stepsCounter;
  }

  private Coordinate NotVisitedConnectionFor(Coordinate coordinate, GardenMap gardenMap)
  {
    var (left, right) = gardenMap.ConnectionsFor(coordinate);

    if(left == null) return right!;
    if(right == null) return left!;

    if (visitedCoordinates.Contains(left!))
      return right!;

    return left!;
  }

}
