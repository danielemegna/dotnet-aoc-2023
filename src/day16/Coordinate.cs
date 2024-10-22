namespace aoc2023.day16;

public record Coordinate(int X, int Y)
{
  public Coordinate Next(ContraptionMap.BeamDirection beamDirection)
  {
    switch (beamDirection)
    {
      case ContraptionMap.BeamDirection.RIGHT:
        return new(X: this.X + 1, Y: this.Y);
      case ContraptionMap.BeamDirection.DOWN:
        return new(X: this.X, Y: this.Y + 1);
      case ContraptionMap.BeamDirection.UP:
      default:
        return new(X: this.X, Y: this.Y - 1);
    }
  }
}

