
namespace aoc2023.day16;

public record Coordinate(int X, int Y)
{
  public Coordinate Next(ContraptionMap.BeamDirection beamDirection)
  {
    return new(X: this.X + 1, Y: 0);
  }
}

