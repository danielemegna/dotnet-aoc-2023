namespace aoc2023.day1;

using Xunit;

public class TrebuchetTest
{
  private readonly Trebuchet solver = new();

  public class FirstPartTest : TrebuchetTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var input = new string[] {
        "1abc2",
        "pqr3stu8vwx",
        "a1b2c3d4e5f",
        "treb7uchet"
      };

      var actual = solver.SumOfCalibrationValuesFor(input, Trebuchet.Mode.ONLY_NUMBERS);

      Assert.Equal(12 + 38 + 15 + 77, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day1/input.txt");
      var actual = solver.SumOfCalibrationValuesFor(input, Trebuchet.Mode.ONLY_NUMBERS);
      Assert.Equal(54388, actual);
    }

    public class CalibrationValueFromRowTest : TrebuchetTest
    {

      [Fact]
      public void CalibrationValueFromRow_withTwoNumbers()
      {
        Assert.Equal(12, solver.CalibrationValueFromRow("1abc2", Trebuchet.Mode.ONLY_NUMBERS));
        Assert.Equal(38, solver.CalibrationValueFromRow("pqr3stu8vwx", Trebuchet.Mode.ONLY_NUMBERS));
      }

      [Fact]
      public void CalibrationValueFromRow_withMoreThanTwoNumbers_shouldTakeFirstAndLast()
      {
        Assert.Equal(15, solver.CalibrationValueFromRow("a1b2c3d4e5f", Trebuchet.Mode.ONLY_NUMBERS));
      }

      [Fact]
      public void CalibrationValueFromRow_withOneNumber_shouldTakeItTwice()
      {
        Assert.Equal(77, solver.CalibrationValueFromRow("treb7uchet", Trebuchet.Mode.ONLY_NUMBERS));
      }

    }

  }

  public class SecondPartTest : TrebuchetTest
  {

    [Fact]
    public void SolveProvidedExample_withSpelledNumbers()
    {
      var input = new string[] {
        "two1nine",
        "eightwothree",
        "abcone2threexyz",
        "xtwone3four",
        "4nineeightseven2",
        "zoneight234",
        "7pqrstsixteen"
      };

      var actual = solver.SumOfCalibrationValuesFor(input, Trebuchet.Mode.NUMBERS_AND_SPELLED);

      Assert.Equal(29 + 83 + 13 + 24 + 42 + 14 + 76, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day1/input.txt");
      var actual = solver.SumOfCalibrationValuesFor(input, Trebuchet.Mode.NUMBERS_AND_SPELLED);
      Assert.Equal(53515, actual);
    }

    public class CalibrationValueFromRowTest : TrebuchetTest
    {

      [Fact]
      public void CalibrationValueFromRow_withSpelledNumbers()
      {
        Assert.Equal(29, solver.CalibrationValueFromRow("two1nine", Trebuchet.Mode.NUMBERS_AND_SPELLED));
        Assert.Equal(13, solver.CalibrationValueFromRow("abcone2threexyz", Trebuchet.Mode.NUMBERS_AND_SPELLED));
        Assert.Equal(42, solver.CalibrationValueFromRow("4nineeightseven2", Trebuchet.Mode.NUMBERS_AND_SPELLED));
      }

      [Fact]
      public void CalibrationValueFromRow_withSpelledNumbers_mixingSpelledWithNormal()
      {
        Assert.Equal(14, solver.CalibrationValueFromRow("zoneight234", Trebuchet.Mode.NUMBERS_AND_SPELLED));
        Assert.Equal(76, solver.CalibrationValueFromRow("7pqrstsixteen", Trebuchet.Mode.NUMBERS_AND_SPELLED));
      }

      [Fact]
      public void CalibrationValueFromRow_withSpelledNumbers_shouldValuateFirstBefore()
      {
        Assert.Equal(83, solver.CalibrationValueFromRow("eightwothree", Trebuchet.Mode.NUMBERS_AND_SPELLED));
        Assert.Equal(24, solver.CalibrationValueFromRow("xtwone3four", Trebuchet.Mode.NUMBERS_AND_SPELLED));
      }

    }

  }

}
