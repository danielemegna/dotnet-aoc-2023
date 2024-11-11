namespace aoc2023.day16;

public record Coordinate(int X, int Y)
{
  public Coordinate NextFor(BeamDirection beamDirection)
  {
    return beamDirection switch
    {
      BeamDirection.RIGHT => this with { X = X + 1 },
      BeamDirection.DOWN => this with { Y = Y + 1 },
      BeamDirection.LEFT => this with { X = X - 1 },
      BeamDirection.UP => this with { Y = Y - 1 },
      _ => throw new ArgumentException($"Cannot get next coordinate for [${beamDirection}]"),
    };
  }
}

