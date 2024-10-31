namespace aoc2023.day16;

public record Coordinate(int X, int Y)
{
  public Coordinate Next(ContraptionMap.BeamDirection beamDirection)
  {
    switch (beamDirection)
    {
      case ContraptionMap.BeamDirection.RIGHT:
        return this with { X = X + 1 };
      case ContraptionMap.BeamDirection.DOWN:
        return this with { Y = Y + 1 };
      case ContraptionMap.BeamDirection.LEFT:
        return this with { X = X - 1 };
      case ContraptionMap.BeamDirection.UP:
        return this with { Y = Y - 1 };
    }

    throw new ArgumentException($"Cannot get Next coordinate for [${beamDirection}]");
  }
}

