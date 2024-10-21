
namespace aoc2023.day16;

public record Coordinate(int X, int Y)
{
  public Coordinate Next(ContraptionMap.BeamDirection beamDirection)
  {
    if (beamDirection == ContraptionMap.BeamDirection.RIGHT)
      return new(X: this.X + 1, Y: 0);

    return new(X: this.X, Y: this.Y + 1);
  }
}

