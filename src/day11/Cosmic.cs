namespace aoc2023.day11;

public class Cosmic
{
  public Cosmic(Coordinate[] galaxies)
  {
  }

  public int ShortestPathLengthBetweenCoordinates(Coordinate from, Coordinate to)
  {
    return Math.Abs(to.X - from.X) + Math.Abs(to.Y - from.Y);
  }
}