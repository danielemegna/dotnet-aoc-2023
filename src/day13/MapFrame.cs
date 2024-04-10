namespace aoc2023.day13;

using System.Collections;

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

  private static int? DoubleCursorScan(string[] inputLines, ScanMode scanMode)
  {
    int lastLineIndex = inputLines.Length - 1;
    int topCursor = 0;
    int bottomCursor = lastLineIndex;

    do
    {
      if (inputLines[topCursor] == inputLines[bottomCursor])
      {
        if (topCursor == bottomCursor - 1) return bottomCursor;
        topCursor++;
        bottomCursor--;
        continue;
      }

      switch (scanMode)
      {
        case ScanMode.FIRST_HALF:
          if (topCursor != 0){
            topCursor = 0;
            continue;
          }
          bottomCursor--;
          continue;

        case ScanMode.SECOND_HALF:
          if (bottomCursor != lastLineIndex) {
            bottomCursor = lastLineIndex;
            continue;
          }
          topCursor++;
          continue;
      }
    } while (topCursor < bottomCursor);

    return null;
  }

  private static int? DetectHorizontalMirror(string[] inputLines)
  {
    return
      DoubleCursorScan(inputLines, ScanMode.FIRST_HALF) ??
      DoubleCursorScan(inputLines, ScanMode.SECOND_HALF);
  }

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(MapFrame)) return false;
    var otherCasted = (MapFrame)other;

    return SourceMap.SequenceEqual(otherCasted.SourceMap);
  }

  public override int GetHashCode() =>
    StructuralComparisons.StructuralEqualityComparer.GetHashCode(SourceMap);

  private enum ScanMode { FIRST_HALF, SECOND_HALF }
}
