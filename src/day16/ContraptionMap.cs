namespace aoc2023.day16;

public class ContraptionMap
{
  private readonly Dictionary<Coordinate, BeamDirection> existingBeams;

  public static ContraptionMap From(string[] inputLines)
  {
    return new ContraptionMap();
  }

  public ContraptionMap()
  {
    this.existingBeams = new()
    {
      [new Coordinate(X: 0, Y: 0)] = BeamDirection.RIGHT
    };
  }

  public Dictionary<Coordinate, BeamDirection> GetExistingBeams()
  {
    return this.existingBeams;
  }

  public void MoveNextAllBeams()
  {
    BeamDirection beamDirection = this.existingBeams.First().Value;
    Coordinate beamCoordinate = this.existingBeams.First().Key;

    var nextCoordinate = beamCoordinate.Next(beamDirection);
    this.existingBeams.Remove(beamCoordinate);
    this.existingBeams[nextCoordinate] = beamDirection;
  }

  public enum BeamDirection { RIGHT }
}
