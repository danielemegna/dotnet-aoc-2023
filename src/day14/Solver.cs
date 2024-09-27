
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
        var totalCyclesTarget = 1_000_000_000;

        var map = RocksMap.From(inputLines);
        var (InitialGap, Frequency) = map.FindCycleOfTiltsRepetitionFrequencyInfo();

        for (int i = 0; i < InitialGap; i++)
        {
            map = map.MakeACycleOfTilts();
        }
        totalCyclesTarget -= InitialGap;

        var rest = totalCyclesTarget % Frequency;
        for (int i = 0; i < rest; i++)
        {
            map = map.MakeACycleOfTilts();
        }

        return map.TotalLoadOnNorth();
    }
}
