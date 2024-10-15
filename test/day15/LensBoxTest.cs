namespace aoc2023.day15;

using Xunit;

public class LensBoxTest
{

  [Fact]
  public void FocusingPowerOfEmptyBoxIsZeroRegardlessTheBoxNumber()
  {
    var box = new LensBox();
    int power = box.FocusingPower(boxNumber: 99);
    Assert.Equal(0, power);
  }

  [Fact]
  public void PutALensInABoxAndGetFocusingPower()
  {
    var box = new LensBox();
    box.AddLens(lensLabel: "rn", lensFocalLength: 3);

    int power = box.FocusingPower(boxNumber: 0);

    Assert.Equal((1 + 0) * 1 * 3, power);
  }

  [Fact]
  public void PutSomeLensInABoxAndGetFocusingPower()
  {
    var box = new LensBox();
    box.AddLens(lensLabel: "ot", lensFocalLength: 7);
    box.AddLens(lensLabel: "ab", lensFocalLength: 5);
    box.AddLens(lensLabel: "pc", lensFocalLength: 6);

    int power = box.FocusingPower(boxNumber: 3);

    var expected =
      ((1 + 3) * 1 * 7) +
      ((1 + 3) * 2 * 5) +
      ((1 + 3) * 3 * 6);
    Assert.Equal(expected, power);
  }

  [Fact]
  public void AddLensWithSameLabelShouldReplacePreviousOne()
  {
    var box = new LensBox();
    box.AddLens(lensLabel: "ot", lensFocalLength: 9);
    box.AddLens(lensLabel: "ab", lensFocalLength: 5);
    box.AddLens(lensLabel: "ot", lensFocalLength: 7);

    int power = box.FocusingPower(boxNumber: 0);

    var expected =
      ((1 + 0) * 1 * 7) +
      ((1 + 0) * 2 * 5);
    Assert.Equal(expected, power);
  }

  [Fact]
  public void RemoveLensFromAnEmptyBox() {
    var box = new LensBox();
    box.RemoveLensWithLabel("cm");
    int power = box.FocusingPower(boxNumber: 99);
    Assert.Equal(0, power);
  }

  [Fact]
  public void PerformSeveralOperationsAndGetFocusingPowerOfBox() {
    var box = new LensBox();

    box.AddLens(lensLabel: "rn", lensFocalLength: 1);
    box.AddLens(lensLabel: "qp", lensFocalLength: 3);
    box.AddLens(lensLabel: "cm", lensFocalLength: 2);
    box.RemoveLensWithLabel("qp");
    box.AddLens(lensLabel: "pc", lensFocalLength: 4);
    box.AddLens(lensLabel: "ab", lensFocalLength: 5);
    box.AddLens(lensLabel: "rn", lensFocalLength: 3);
    box.RemoveLensWithLabel("pc");
    box.AddLens(lensLabel: "ot", lensFocalLength: 7);
    box.AddLens(lensLabel: "pc", lensFocalLength: 6);

    int power = box.FocusingPower(boxNumber: 9);

    var expected =
      ((1 + 9) * 1 * 3) +
      ((1 + 9) * 2 * 2) +
      ((1 + 9) * 3 * 5) +
      ((1 + 9) * 4 * 7) +
      ((1 + 9) * 5 * 6);
    Assert.Equal(expected, power);
  }

}
