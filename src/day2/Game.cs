namespace aoc2023.day2;

public enum CubeColor { BLUE, RED, GREEN };

public class Game(int id)
{
  public int Id { get; } = id;
  private int MaxBlueCubesCount = 0;
  private int MaxRedCubesCount = 0;
  private int MaxGreenCubesCount = 0;

  public void AddSet(Set gameSet)
  {
    if (MaxBlueCubesCount < gameSet.BlueCubesCount)
      MaxBlueCubesCount = gameSet.BlueCubesCount;
    if (MaxRedCubesCount < gameSet.RedCubesCount)
      MaxRedCubesCount = gameSet.RedCubesCount;
    if (MaxGreenCubesCount < gameSet.GreenCubesCount)
      MaxGreenCubesCount = gameSet.GreenCubesCount;
  }

  public int MaxCountInSet(CubeColor cubeColor)
  {
    return cubeColor switch
    {
      CubeColor.BLUE => MaxBlueCubesCount,
      CubeColor.RED => MaxRedCubesCount,
      CubeColor.GREEN => MaxGreenCubesCount,
    };
  }

  public long PowerOfMinimumNeededCubes()
  {
    return MaxBlueCubesCount * MaxRedCubesCount * MaxGreenCubesCount;
  }

  public class Set()
  {
    public int BlueCubesCount { get; private set; } = 0;
    public int RedCubesCount { get; private set; } = 0;
    public int GreenCubesCount { get; private set; } = 0;

    public void AddCubeCount(CubeColor color, int count)
    {
      switch (color)
      {
        case CubeColor.BLUE:
          BlueCubesCount = count;
          break;
        case CubeColor.RED:
          RedCubesCount = count;
          break;
        case CubeColor.GREEN:
          GreenCubesCount = count;
          break;
      }
    }
  }

}

