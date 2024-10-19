namespace aoc2023.day16;

public class ContraptionMap
{
  private readonly int size;
  private readonly Dictionary<Coordinate, BeamDirection> existingBeams;

  public static ContraptionMap From(string[] inputLines)
  {
    return new ContraptionMap(size: inputLines.Length);
  }

  public ContraptionMap(int size)
  {
    this.size = size;
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
    Coordinate beamCoordinate = this.existingBeams.First().Key;
    BeamDirection beamDirection = this.existingBeams.First().Value;

    this.existingBeams.Remove(beamCoordinate);

    var nextCoordinate = beamCoordinate.Next(beamDirection);
    if (nextCoordinate.X < this.size)
      this.existingBeams[nextCoordinate] = beamDirection;
  }

  public enum BeamDirection { RIGHT }
}
