namespace aoc2023.day14;

using System.Collections;

class RocksMap
{
    private readonly VerticalRockRow[] mapRows;

    private RocksMap(IEnumerable<VerticalRockRow> mapRows) : this(mapRows.ToArray()) { }
    private RocksMap(VerticalRockRow[] mapRows) { this.mapRows = mapRows; }

    public static RocksMap From(string[] inputLines)
    {
        MapObject[][] matrixOfObjects = inputLines
            .Select(line => line.ToCharArray())
            .Select(chars => chars.Select(ToMapObject).ToArray())
            .ToArray();

        List<VerticalRockRow> verticalRockRows = [];
        for (int x = 0; x < inputLines[0].Length; x++)
        {
            List<MapObject> verticalRowObjects = [];
            for (int y = 0; y < inputLines.Length; y++)
                verticalRowObjects.Add(matrixOfObjects[y][x]);

            verticalRockRows.Add(new VerticalRockRow(verticalRowObjects));
        }

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

    public RocksMap TurnClockwise()
    {
        var mapSizeRange = Enumerable.Range(0, mapRows.Length);
        var newRows = mapSizeRange.Reverse().Select((y) =>
        {
            var newVerticalRowObjects = mapSizeRange.Select((x) => mapRows[x].At(y));
            return new VerticalRockRow(newVerticalRowObjects);
        });

        return new RocksMap(newRows);
    }

    public RocksMap MakeACycleOfTilts()
    {
        RocksMap result = this.Clone();
        for (int i = 0; i < 4; i++)
        {
            result = result.TiltOnNorth();
            result = result.TurnClockwise();
        }

        return result;
    }

    public RepetitionFrequencyInfo FindCycleOfTiltsRepetitionFrequencyInfo()
    {
        var actualMap = this.Clone();
        List<RocksMap> encounteredMaps = [actualMap.Clone()];

        while (true)
        {
            actualMap = actualMap.MakeACycleOfTilts();
            int findResultIndex = encounteredMaps.FindIndex(map => map.Equals(actualMap));
            if (findResultIndex < 0)
            {
                encounteredMaps.Add(actualMap.Clone());
                continue;
            }

            return new RepetitionFrequencyInfo(
                InitialGap: findResultIndex,
                Frequency: encounteredMaps.Count - findResultIndex
            );
        }
    }

    private RocksMap Clone()
    {
        var rows = mapRows.Select(r => r.Clone());
        return new RocksMap(rows);
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
