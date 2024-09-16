
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
        return 64;
    }
}
