﻿namespace aoc2023;

using Xunit;

public class TrebuchetTest
{
  private Trebuchet solver = new Trebuchet();

  #region -- First part --

  [Fact]
  public void SolveTheProvidedExample()
  {
    var input = new string[] {
      "1abc2",
      "pqr3stu8vwx",
      "a1b2c3d4e5f",
      "treb7uchet"
    };

    var actual = solver.SumOfCalibrationValuesFor(input);

    Assert.Equal(12 + 38 + 15 + 77, actual);
  }

  [Fact]
  public void SolveWithFile()
  {
    var input = File.ReadAllLines("day1/input.txt");
    var actual = solver.SumOfCalibrationValuesFor(input);
    Assert.Equal(54388, actual);
  }


  #region -- CalibrationValueFromRow --

  [Fact]
  public void CalibrationValueFromRow_withTwoNumbers()
  {
    Assert.Equal(12, solver.CalibrationValueFromRow("1abc2"));
    Assert.Equal(38, solver.CalibrationValueFromRow("pqr3stu8vwx"));
  }

  [Fact]
  public void CalibrationValueFromRow_withMoreThanTwoNumbers_shouldTakeFirstAndLast()
  {
    Assert.Equal(15, solver.CalibrationValueFromRow("a1b2c3d4e5f"));
  }

  [Fact]
  public void CalibrationValueFromRow_withOneNumber_shouldTakeItTwice()
  {
    Assert.Equal(77, solver.CalibrationValueFromRow("treb7uchet"));
  }

  #endregion

  #endregion

  #region -- Second part --

  [Fact(Skip = "WIP")]
  public void SolveProvidedExampleWithSpelledNumbers()
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

    var actual = solver.SumOfCalibrationValuesFor(input);

    Assert.Equal(29 + 83 + 13 + 24 + 42 + 14 + 76, actual);
  }

  #endregion

}
