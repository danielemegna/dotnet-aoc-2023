namespace aoc2023.day13;

class MapFrame(
  int height,
  int width,
  int? horizontalMirrorPosition,
  int? verticalMirrorPosition
)
{
  public int Height { get; } = height;
  public int Width { get; } = width;
  public int? HorizontalMirrorPosition { get; } = horizontalMirrorPosition;
  public int? VerticalMirrorPosition { get; } = verticalMirrorPosition;

  public bool HasHorizontalMirror => this.HorizontalMirrorPosition != null;
  public bool HasVerticalMirror => this.VerticalMirrorPosition != null;

  public static MapFrame From(string[] inputLines)
  {
    var horizontalMirrorPosition = DetectHorizontalMirror(inputLines);
    var verticalMirrorPosition = DetectVerticalMirror(inputLines);
    return new MapFrame(
      inputLines.Length,
      inputLines[0].Length,
      horizontalMirrorPosition,
      verticalMirrorPosition
    );
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

    // TODO find a better way to double scan mirrors and remove duplication
    topCursor = 0;
    bottomCursor = inputLines.Length - 1;
    while (topCursor < bottomCursor)
    {
      if (inputLines[topCursor] != inputLines[bottomCursor])
      {
        bottomCursor--;
        topCursor = 0;
        continue;
      }

      if (topCursor == bottomCursor - 1) return bottomCursor;
      bottomCursor--;
      topCursor++;
    }

    return null;
  }

}
