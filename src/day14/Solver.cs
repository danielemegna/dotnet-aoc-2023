
namespace aoc2023.day14;

class Solver
{
  public int TotalLoadOnNorthTilting(string[] inputLines)
  {
    var map = RocksMap.From(inputLines);
    var tiltedMap = map.TiltOnNorth();
    return tiltedMap.TotalLoadOnNorth();
  }

  public int TotalLoadOnNorthAfterOneBilionOfTilting(string[] inputLines)
  {
    var map = RocksMap.From(inputLines);

    var repetitionFrequencyInfo = map.FindCycleOfTiltsRepetitionFrequencyInfo();
    var cyclesNeededToReachRepetitionsStart = repetitionFrequencyInfo.InitialGap;
    var repetitionSize = repetitionFrequencyInfo.Frequency;

    var totalCyclesTarget = 1_000_000_000;
    var extraCyclesNeededAfterRepetitions = (totalCyclesTarget - cyclesNeededToReachRepetitionsStart) % repetitionSize;
    var optimizedCyclesToDo = cyclesNeededToReachRepetitionsStart + extraCyclesNeededAfterRepetitions;

    for (int i = 0; i < optimizedCyclesToDo; i++)
      map = map.MakeACycleOfTilts();

    return map.TotalLoadOnNorth();
  }
}
