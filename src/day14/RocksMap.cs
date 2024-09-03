namespace aoc2023.day14;

class RocksMap
{
    private readonly MapObject[][] objects;

    public RocksMap(MapObject[][] objects)
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

    public MapObject At(int x, int y)
    {
        return objects[y][x];
    }

    public int LoadOnNorthAt(int x, int y)
    {
        var mapObject = At(x, y);
        if (mapObject != MapObject.ROUND_ROCK)
            return 0;

        return objects.Length - y;
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
}

public enum MapObject { EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK }
