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
}

public enum MapObject { EMPTY_SPACE, ROUND_ROCK, CUBE_ROCK }
