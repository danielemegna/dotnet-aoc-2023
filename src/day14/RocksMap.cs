namespace aoc2023.day14;

using System.Collections;

class RocksMap
{
    private readonly VerticalRockRow[] mapRows;

    private RocksMap(VerticalRockRow[] mapRows)
    {
        this.mapRows = mapRows;
    }

    public static RocksMap From(string[] inputLines)
    {
        var accumulator = inputLines[0]
            .ToCharArray()
            .Select(c => new List<MapObject>())
            .ToArray();

        var verticalRockRows = inputLines.Aggregate(accumulator, (acc, line) =>
        {
            var charArray = line.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                MapObject currrentMapObject = ToMapObject(charArray[i]);
                List<MapObject> verticalRockRowObjectAccumulator = acc.ElementAt(i);
                verticalRockRowObjectAccumulator.Add(currrentMapObject);
            }
            return acc;
        })
        .Select(mapObjects => new VerticalRockRow(mapObjects.ToArray()))
        .ToArray();

        return new RocksMap(verticalRockRows);
    }

    private static MapObject ToMapObject(char mapObjectChar)
    {
        return mapObjectChar switch
        {
            '.' => MapObject.EMPTY_SPACE,
            'O' => MapObject.ROUND_ROCK,
            '#' => MapObject.CUBE_ROCK,
            _ => throw new FormatException($"Cannot parse map object [{mapObjectChar}]"),
        };
    }

    public int TotalLoadOnNorth()
    {
        return mapRows.Select(r => r.GetLoad()).Sum();
    }

    public RocksMap TiltOnNorth()
    {
        var newRows = (VerticalRockRow[])mapRows.Clone();

        foreach (var row in newRows)
            row.Tilt();

        return new RocksMap(newRows);
    }

    public override bool Equals(object? other)
    {
        if (this == other) return true;
        if (other is null) return false;
        if (other.GetType() != typeof(RocksMap)) return false;
        var otherCasted = (RocksMap)other;

        return StructuralComparisons.StructuralEqualityComparer.Equals(mapRows, otherCasted.mapRows);
    }

    public override int GetHashCode() =>
      StructuralComparisons.StructuralEqualityComparer.GetHashCode(mapRows);
}
