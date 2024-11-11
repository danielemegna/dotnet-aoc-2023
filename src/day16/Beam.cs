namespace aoc2023.day16;

public record Beam(Coordinate Coordinate, BeamDirection Direction)
{
  public Beam StepForward()
  {
    return this with
    {
      Coordinate = this.Coordinate.Next(this.Direction)
    };
  }
}


public enum BeamDirection { RIGHT, DOWN, UP, LEFT }
