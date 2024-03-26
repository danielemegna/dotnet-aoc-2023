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
    var columnsCount = inputLines[0].Length;
    var transposedMap = Enumerable.Range(0, columnsCount)
      .Select(index => string.Join("", inputLines.Select(line => line[index])))
      .ToArray();

    return DetectHorizontalMirror(transposedMap);
  }

  private static int? DetectHorizontalMirror(string[] inputLines)
  {
    int topIndex = 0;
    int bottomIndex = inputLines.Length - 1;

    do
    {

      if (inputLines[topIndex] == inputLines[bottomIndex])
      {
        if (topIndex == bottomIndex - 1) return bottomIndex;
        bottomIndex--;
        topIndex++;
        continue;
      }

      bottomIndex = inputLines.Length - 1;
      topIndex++;
    }
    while (topIndex < bottomIndex);

    return null;
  }

  public MapFrame(int? horizontalMirrorPosition, int? verticalMirrorPosition)
  {
    this.HorizontalMirrorPosition = horizontalMirrorPosition;
    this.VerticalMirrorPosition = verticalMirrorPosition;
  }

}
