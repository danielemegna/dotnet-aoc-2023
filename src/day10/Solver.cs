namespace aoc2023.day10;

class Solver
{

  public int FarthestPointFromStartDistance(string[] inputLines)
  {
    var gardenMap = GardenMap.From(inputLines);
    return gardenMap.LoopLength / 2;
  }

  public int CountAreasInsideTheLoop(string[] inputLines)
  {
    var gardenMap = GardenMap.From(inputLines);
    var rayCastingGun = new RayCastingGun(gardenMap);
    return rayCastingGun.InsideTheLoopCoordinateCount();
  }
}
