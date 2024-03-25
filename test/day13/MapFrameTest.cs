namespace aoc2023.day13;

using Xunit;

public class MapFrameTest
{

  public static readonly string[] FIRST_MAP_PROVIDED_EXAMPLE_INPUT_LINES = [
    "#.##..##.",
    "..#.##.#.",
    "##......#",
    "##......#",
    "..#.##.#.",
    "..##..##.",
    "#.#.##.#."
  ];

  public static readonly string[] SECOND_MAP_PROVIDED_EXAMPLE_INPUT_LINES = [
    "#...##..#",
    "#....#..#",
    "..##..###",
    "#####.##.",
    "#####.##.",
    "..##..###",
    "#....#..#"
  ];

  [Fact(Skip = "WIP")]
  public void FirstProvidedExampleHasVerticalMirror()
  {
    var mapFrame = MapFrame.From(FIRST_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.True(mapFrame.HasVerticalMirror);
  }

  [Fact]
  public void FirstProvidedExampleDoesNotHaveHorizontalMirror()
  {
    var mapFrame = MapFrame.From(FIRST_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.False(mapFrame.HasHorizontalMirror);
  }

  [Fact]
  public void SecondProvidedExampleHasHorizontalMirror()
  {
    var mapFrame = MapFrame.From(SECOND_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.True(mapFrame.HasHorizontalMirror);
  }

  [Fact]
  public void SecondProvidedExampleDoesNotHaveVerticalMirror()
  {
    var mapFrame = MapFrame.From(SECOND_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.False(mapFrame.HasVerticalMirror);
  }

}