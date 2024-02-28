namespace aoc2023.day10;

class Solver
{

  public int FarthestPointFromStartDistance(string[] inputLines)
  {
    var gardenMap = GardenMap.From(inputLines);
    return gardenMap.LoopLength / 2;
  }

}
