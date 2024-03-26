namespace aoc2023.day13;

class Solver
{
  public int SummarizePatternNotes(string[] inputLines)
  {
    List<MapFrame> mapFrames = ParseMapFrames(inputLines);

    return mapFrames
      .Select(map =>
      {
        if (map.HasVerticalMirror)
          return map.VerticalMirrorPosition!.Value;
        if (map.HasHorizontalMirror)
          return 100 * map.HorizontalMirrorPosition!.Value;

        throw new SystemException("Detected map without any mirror! Something strange here..");
      }).Sum();
  }

  private List<MapFrame> ParseMapFrames(string[] inputLines)
  {
    List<MapFrame> result = [];
    int cursor = 0;

    List<string> mapLines = [];
    while (cursor < inputLines.Length)
    {
      var line = inputLines[cursor];
      cursor++;

      if (line != "")
      {
        mapLines.Add(line);
        continue;
      }

      result.Add(MapFrame.From(mapLines.ToArray()));
      mapLines.Clear();
    }

    // probably we can do something better here ..
    result.Add(MapFrame.From(mapLines.ToArray()));

    return result;
  }
}