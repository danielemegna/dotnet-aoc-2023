namespace aoc2023;

using Xunit;

public class TrebuchetTest
{

  [Fact]
  public void SolveTheProvidedExample()
  {
    var input = "1abc2\n" +
      "pqr3stu8vwx\n" +
      "a1b2c3d4e5f\n" +
      "treb7uchet\n";
    var trebuchet = new Trebuchet();

    var actual = trebuchet.SumOfCalibrationValuesFor(input);

    Assert.Equal(142, actual);
  }

}
