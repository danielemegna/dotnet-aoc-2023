namespace aoc2023.day13;

class MapFrame
{
  public int? HorizontalMirrorPosition { get; }
  public int? VerticalMirrorPosition { get; }
  public bool HasHorizontalMirror => this.HorizontalMirrorPosition != null;
  public bool HasVerticalMirror => this.VerticalMirrorPosition != null;

  public static MapFrame From(string[] inputLines)
  {
    var horizontalMirrorPosition = DetectHorizontalMirror(inputLines);
    var verticalMirrorPosition = DetectVerticalMirror(inputLines);
    return new MapFrame(horizontalMirrorPosition, verticalMirrorPosition);
  }

  private static int? DetectVerticalMirror(string[] inputLines)
  {
    var transposedMap = Enumerable.Range(0, inputLines[0].Length)
      .Select(index => string.Join("", inputLines.Select(line => line[index])))
      .ToArray();

    return DetectHorizontalMirror(transposedMap);
  }

  private static int? DetectHorizontalMirror(string[] inputLines)
  {
    int topCursor = 0;
    int bottomCursor = inputLines.Length - 1;

    while (topCursor < bottomCursor)
    {
      if (inputLines[topCursor] != inputLines[bottomCursor])
      {
        topCursor++;
        bottomCursor = inputLines.Length - 1;
        continue;
      }

      if (topCursor == bottomCursor - 1) return bottomCursor;
      topCursor++;
      bottomCursor--;
    }

    return null;
  }

  public MapFrame(int? horizontalMirrorPosition, int? verticalMirrorPosition)
  {
    this.HorizontalMirrorPosition = horizontalMirrorPosition;
    this.VerticalMirrorPosition = verticalMirrorPosition;
  }

}
