namespace aoc2023.day22;

public class BrickParser
{
  public ISet<Brick> ParseBricks(string[] inputLines)
  {
    return inputLines
      .Select(inputLine =>
      {
        (Coordinate start, Coordinate end) = CoordinatesFrom(inputLine);
        return new Brick(start, end);
      }).ToHashSet();
  }

  private (Coordinate, Coordinate) CoordinatesFrom(string line)
  {
    var foo = line.Split("~").Select(coordinateString =>
    {
      var coordinateParts = coordinateString.Split(",").Select(n => int.Parse(n)).ToArray();
      return new Coordinate(coordinateParts[0], coordinateParts[1], coordinateParts[2]);
    });

    return (foo.ElementAt(0), foo.ElementAt(1));
  }
}
