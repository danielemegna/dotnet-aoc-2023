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

  public static readonly string[] ANOTHER_MAP_INPUT_LINES = [
    ".##..###",
    "####.##.",
    "####.##.",
    ".##..###",
    "....#.##",
    "...##..#",
    "..#.#..#",
    "#......#",
  ];

  [Fact]
  public void FirstProvidedExampleHasVerticalMirror()
  {
    var mapFrame = MapFrame.From(FIRST_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.True(mapFrame.HasVerticalMirror);
    Assert.Equal(5, mapFrame.VerticalMirrorPosition);
  }

  [Fact]
  public void FirstProvidedExampleDoesNotHaveHorizontalMirror()
  {
    var mapFrame = MapFrame.From(FIRST_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.False(mapFrame.HasHorizontalMirror);
    Assert.Null(mapFrame.HorizontalMirrorPosition);
  }

  [Fact]
  public void SecondProvidedExampleHasHorizontalMirror()
  {
    var mapFrame = MapFrame.From(SECOND_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.True(mapFrame.HasHorizontalMirror);
    Assert.Equal(4, mapFrame.HorizontalMirrorPosition);
  }

  [Fact]
  public void SecondProvidedExampleDoesNotHaveVerticalMirror()
  {
    var mapFrame = MapFrame.From(SECOND_MAP_PROVIDED_EXAMPLE_INPUT_LINES);
    Assert.False(mapFrame.HasVerticalMirror);
    Assert.Null(mapFrame.VerticalMirrorPosition);
  }

  [Fact]
  public void AnotherMapHasHorizontalMirrorInTheFirstHalf()
  {
    var mapFrame = MapFrame.From(ANOTHER_MAP_INPUT_LINES);
    Assert.True(mapFrame.HasHorizontalMirror);
    Assert.False(mapFrame.HasVerticalMirror);
    Assert.Equal(2, mapFrame.HorizontalMirrorPosition);
    Assert.Null(mapFrame.VerticalMirrorPosition);
  }


}
