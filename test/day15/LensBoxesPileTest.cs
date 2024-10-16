namespace aoc2023.day15;

using Xunit;

public class LensBoxesPileTest
{

  [Fact]
  public void TotalFocusingPowerForEmptyPile()
  {
    var pile = new LensBoxesPile(size: 6);
    var power = pile.TotalFocusingPower();
    Assert.Equal(0, power);
  }

  [Fact]
  public void TotalFocusingPowerAfterSingleAddOperation()
  {
    var pile = new LensBoxesPile(size: 6);
    var addOperation = new AddLensOperation(Label: "cm", FocalLength: 3);

    pile.Apply(operation: addOperation, boxNumber: 0);
    var power = pile.TotalFocusingPower();

    var expectedPower = (0 + 1) * 1 * 3;
    Assert.Equal(expectedPower, power);
  }

  [Fact]
  public void OperationAttemptOnOutOfBoundBoxIndex()
  {
    var pile = new LensBoxesPile(size: 6);
    var addOperation = new AddLensOperation(Label: "cm", FocalLength: 3);

    var ex = Assert.Throws<IndexOutOfRangeException>(() =>
      pile.Apply(operation: addOperation, boxNumber: 99)
    );
    Assert.Equal("Cannot apply operation on box [99], LensBoxesPile size [6]", ex.Message);

    ex = Assert.Throws<IndexOutOfRangeException>(() =>
      pile.Apply(operation: addOperation, boxNumber: 6)
    );
    Assert.Equal("Cannot apply operation on box [6], LensBoxesPile size [6]", ex.Message);
  }

}