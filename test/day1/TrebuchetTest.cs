namespace aoc2023;

using Xunit;

public class TrebuchetTest
{
  private Trebuchet solver = new Trebuchet();

  [Fact]
  public void SolveTheProvidedExample()
  {
    var input = "1abc2\n" +
      "pqr3stu8vwx\n" +
      "a1b2c3d4e5f\n" +
      "treb7uchet\n";

    var actual = solver.SumOfCalibrationValuesFor(input);

    Assert.Equal(142, actual);
  }

  [Fact]
  public void SolveWithFile()
  {
    var input = File.ReadAllText( "day1/input.txt");
    var actual = solver.SumOfCalibrationValuesFor(input);
    Assert.Equal(54388, actual);
  }
}
