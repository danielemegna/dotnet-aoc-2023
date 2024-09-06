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
            return line.ToCharArray().Select((mapObjectChar) =>
            {
                return mapObjectChar switch
                {
                    '.' => MapObject.EMPTY_SPACE,
                    'O' => MapObject.ROUND_ROCK,
                    '#' => MapObject.CUBE_ROCK,
                    _ => throw new FormatException($"Cannot parse map object [{mapObjectChar}]"),
                };
            }).ToArray();
        }).ToArray();
        return new RocksMap(mapOfObjects);
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
        objectsClone[0][1] = MapObject.ROUND_ROCK;

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
