namespace aoc2023.day11;

public class Cosmic
{
  private readonly Coordinate[] galaxies;

  public Cosmic(Coordinate[] galaxies)
  {
    this.galaxies = galaxies;
  }

  internal int ShortestPathLengthBetweenCoordinates(Coordinate from, Coordinate to)
  {
    return Math.Abs(to.X - from.X) + Math.Abs(to.Y - from.Y);
  }

  public int SumOfShortestPathsBetweenGalaxies()
  {
    int result = 0;
    for (int i = 0; i < galaxies.Length; i++)
    {
      for (int j = i+1; j < galaxies.Length; j++)
      {
        result += ShortestPathLengthBetweenCoordinates(galaxies[i], galaxies[j]);
      }
    }
    return result;
  }
}