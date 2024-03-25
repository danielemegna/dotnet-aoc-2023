namespace aoc2023.day13;

class MapFrame
{
  public bool HasHorizontalMirror { get; }
  public bool HasVerticalMirror { get; }

  public static MapFrame From(string[] inputLines)
  {
    var hasHorizontalMirror = DetectHorizontalMirror(inputLines);
    return new MapFrame(hasHorizontalMirror);
  }

  private static bool DetectHorizontalMirror(string[] inputLines)
  {
    int topIndex = 0;
    int bottomIndex = inputLines.Length - 1;

    do
    {

      if (inputLines[topIndex] == inputLines[bottomIndex])
      {
        if (topIndex == bottomIndex - 1) return true;
        bottomIndex--;
        topIndex++;
        continue;
      }

      bottomIndex = inputLines.Length - 1;
      topIndex++;
    }
    while (topIndex < bottomIndex);

    return false;
  }

  public MapFrame(bool hasHorizontalMirror)
  {
    this.HasHorizontalMirror = hasHorizontalMirror;
    this.HasVerticalMirror = false;
  }

}