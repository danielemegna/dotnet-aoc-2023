using System.Collections;

namespace aoc2023.day14;

class RocksMap
{
    private readonly MapObject[][] objects;

    private RocksMap(MapObject[][] objects)
    {
        this.objects = objects;
    }

    public static RocksMap From(string[] inputLines)
    {
        var mapOfObjects = inputLines.Select((line) =>
        {
            return line
                .ToCharArray()
                .Select((mapObjectChar) => ToMapObject(mapObjectChar))
                .ToArray();
        }).ToArray();
        return new RocksMap(mapOfObjects);
    }

    public static RocksMap WIPVerticalRockRowFrom(string[] inputLines)
    {
        List<MapObject>[] accumulator = inputLines[0].ToCharArray().Select(c =>
        {
            return new List<MapObject> { ToMapObject(c) };
        }).ToArray();

        var verticalRockRows = inputLines.Skip(1).Aggregate(accumulator, (acc, line) =>
        {
            var charArray = line.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                acc.ElementAt(i).Add(ToMapObject(charArray[i]));
            }
            return acc;
        }).Select(mapObjects => new VerticalRockRow(mapObjects.ToArray())).ToArray();

        return new RocksMap([] /* verticalRockRows */);
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
        int totalLoad = 0;
        for (int y = 0; y < objects.Length; y++)
        {
            for (int x = 0; x < objects[y].Length; x++)
            {
                totalLoad += LoadOnNorthAt(x, y);
            }
        }
        return totalLoad;
    }

    internal int LoadOnNorthAt(int x, int y)
    {
        var mapObject = At(x, y);
        if (mapObject != MapObject.ROUND_ROCK)
            return 0;

        return objects.Length - y;
    }

    internal MapObject At(int x, int y)
    {
        return objects[y][x];
    }

    public RocksMap TiltOnNorth()
    {
        MapObject[][] objectsClone = CloneObjects();

        for (int y = 1; y < objectsClone.Length; y++)
        {
            var currentRow = objectsClone[y];
            for (int x = 0; x < currentRow.Length; x++)
            {
                var currentObject = currentRow[x];
                if (currentObject != MapObject.ROUND_ROCK)
                    continue;

                for (int k = y; k > 0; k--)
                {
                    var processingRow = objectsClone[k];
                    var aboveRow = objectsClone[k - 1];
                    var aboveObject = aboveRow[x];
                    if (aboveObject != MapObject.EMPTY_SPACE)
                        break;

                    processingRow[x] = MapObject.EMPTY_SPACE;
                    aboveRow[x] = MapObject.ROUND_ROCK;
                }
            }
        }

        return new RocksMap(objectsClone);
    }

    private MapObject[][] CloneObjects() =>
        this.objects.Select((row) => (MapObject[])row.Clone()).ToArray();

    public override bool Equals(object? other)
    {
        if (this == other) return true;
        if (other is null) return false;
        if (other.GetType() != typeof(RocksMap)) return false;
        var otherCasted = (RocksMap)other;

        return StructuralComparisons.StructuralEqualityComparer.Equals(objects, otherCasted.objects);
    }

    public override int GetHashCode() =>
      StructuralComparisons.StructuralEqualityComparer.GetHashCode(objects);
}

public enum MapObject { EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK }
