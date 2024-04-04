namespace aoc2023.day13;

class MapFrame
{
  public string[] SourceMap { get; }
  public int? HorizontalMirrorPosition { get; }
  public int? VerticalMirrorPosition { get; }

  public int Height => SourceMap.Length;
  public int Width => SourceMap[0].Length;
  public bool HasHorizontalMirror => this.HorizontalMirrorPosition != null;
  public bool HasVerticalMirror => this.VerticalMirrorPosition != null;

  public static MapFrame From(string[] inputLines) => new(inputLines);

  private MapFrame(string[] sourceMap)
  {
    this.SourceMap = sourceMap;
    this.HorizontalMirrorPosition = DetectHorizontalMirror(sourceMap);
    this.VerticalMirrorPosition = DetectVerticalMirror(sourceMap);
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
    int lastLineIndex = inputLines.Length - 1;

    int topCursor = 0;
    int bottomCursor = lastLineIndex;
    while (topCursor < bottomCursor)
    {
      if (inputLines[topCursor] != inputLines[bottomCursor])
      {
        if (bottomCursor != lastLineIndex)
          bottomCursor = lastLineIndex;
        else
          topCursor++;
        continue;
      }

      if (topCursor == bottomCursor - 1) return bottomCursor;
      topCursor++;
      bottomCursor--;
    }

    // TODO find a better way to double scan mirrors and remove duplication
    topCursor = 0;
    bottomCursor = lastLineIndex;
    while (topCursor < bottomCursor)
    {
      if (inputLines[topCursor] != inputLines[bottomCursor])
      {
        if (topCursor != 0)
          topCursor = 0;
        else
          bottomCursor--;
        continue;
      }

      if (topCursor == bottomCursor - 1) return bottomCursor;
      bottomCursor--;
      topCursor++;
    }

    return null;
  }

}
