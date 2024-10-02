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
    box.AddLens(new Lens(Label: "rn", FocalLength: 3));

    int power = box.FocusingPower(boxNumber: 0);

    Assert.Equal((1 + 0) * 1 * 3, power);
  }

  [Fact]
  public void PutSomeLensInABoxAndGetFocusingPower()
  {
    var box = new LensBox();
    box.AddLens(new Lens(Label: "ot", FocalLength: 7));
    box.AddLens(new Lens(Label: "ab", FocalLength: 5));
    box.AddLens(new Lens(Label: "pc", FocalLength: 6));

    int power = box.FocusingPower(boxNumber: 3);

    var expected =
      ((1 + 3) * 1 * 7) +
      ((1 + 3) * 2 * 5) +
      ((1 + 3) * 3 * 6);
    Assert.Equal(expected, power);
  }

  //[Fact]
  //public void RemoveLensFromAnEmptyBox()

  //[Fact]
  //public void PutAndRemoveSomeLensInABoxAndGetFocusingPower()

  //[Fact]
  //public void AddLensWithSameLabelShouldReplacePreviousOne()

}
