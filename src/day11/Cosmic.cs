namespace aoc2023.day11;

public class Cosmic
{
  private Coordinate[] galaxies;

  public Cosmic(Coordinate[] galaxies)
  {
    this.galaxies = galaxies;
  }

  public int ShortestPathBetweenGalaxiesLength(Coordinate from, Coordinate to)
  {
    return (to.X - from.X) + (to.Y - from.Y);
  }
}