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

  public static readonly string[] COMPLEX_MAP_INPUT_LINES = [
    "######..##.",
    "#....#.#.##",
    ".#..#..##..",
    ".#..#..##..",
    "#....#.#.##",
    "######..##.",
    "######..##.",
    "######.....",
    ".###..##..#",
    "#....##.#..",
    "#....###..#",
    "#.##.#.#.#.",
    "######..##.",
    "#.##.#.#...",
    ".####.##..."
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

  [Fact]
  public void ComplexMapHasHorizontalMirror()
  {
    var mapFrame = MapFrame.From(COMPLEX_MAP_INPUT_LINES);
    Assert.True(mapFrame.HasHorizontalMirror);
    Assert.False(mapFrame.HasVerticalMirror);
    Assert.Equal(3, mapFrame.HorizontalMirrorPosition);
    Assert.Null(mapFrame.VerticalMirrorPosition);
  }

  [Fact]
  public void GetMapWidth()
  {
    Assert.Equal(9, MapFrame.From(FIRST_MAP_PROVIDED_EXAMPLE_INPUT_LINES).Width);
    Assert.Equal(9, MapFrame.From(SECOND_MAP_PROVIDED_EXAMPLE_INPUT_LINES).Width);
    Assert.Equal(8, MapFrame.From(ANOTHER_MAP_INPUT_LINES).Width);
    Assert.Equal(11, MapFrame.From(COMPLEX_MAP_INPUT_LINES).Width);
  }

  [Fact]
  public void GetMapHeight()
  {
    Assert.Equal(7, MapFrame.From(FIRST_MAP_PROVIDED_EXAMPLE_INPUT_LINES).Height);
    Assert.Equal(7, MapFrame.From(SECOND_MAP_PROVIDED_EXAMPLE_INPUT_LINES).Height);
    Assert.Equal(8, MapFrame.From(ANOTHER_MAP_INPUT_LINES).Height);
    Assert.Equal(15, MapFrame.From(COMPLEX_MAP_INPUT_LINES).Height);
  }

}
