
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
        for (int i = 0; i < 1000; i++)
        {
            map = map.MakeACycleOfTilts();
        }

        return map.TotalLoadOnNorth();
    }
}
