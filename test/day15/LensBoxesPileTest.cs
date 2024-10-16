namespace aoc2023.day15;

using Xunit;

public class LensBoxesPileTest
{
  private LensBoxesPile pile = new LensBoxesPile(size: 6);

  [Fact]
  public void TotalFocusingPowerForEmptyPile()
  {
    var power = pile.TotalFocusingPower();
    Assert.Equal(0, power);
  }

  [Fact]
  public void TotalFocusingPowerAfterSingleAddOperation()
  {
    var addOperation = new AddLensOperation(Label: "cm", FocalLength: 3);

    pile.Apply(operation: addOperation, boxNumber: 0);
    var power = pile.TotalFocusingPower();

    var expectedPower = (0 + 1) * 1 * 3;
    Assert.Equal(expectedPower, power);
  }

  [Fact]
  public void OperationAttemptOnOutOfBoundBoxIndex()
  {
    var ex = Assert.Throws<IndexOutOfRangeException>(() =>
    {
      var addOperation = new AddLensOperation(Label: "cm", FocalLength: 3);
      pile.Apply(operation: addOperation, boxNumber: 99);
    });
    Assert.Equal("Cannot apply operation on box [99], LensBoxesPile size [6]", ex.Message);

    ex = Assert.Throws<IndexOutOfRangeException>(() =>
    {
      var removeOperation = new RemoveLensOperation(Label: "cm");
      pile.Apply(operation: removeOperation, boxNumber: 6);
    });
    Assert.Equal("Cannot apply operation on box [6], LensBoxesPile size [6]", ex.Message);
  }

  [Fact]
  public void TotalFocusingPowerAfterAddAndRemoveSomeLens()
  {
    pile.Apply(operation: new AddLensOperation(Label: "ot", FocalLength: 9), boxNumber: 3);
    pile.Apply(operation: new AddLensOperation(Label: "pc", FocalLength: 4), boxNumber: 3);
    pile.Apply(operation: new AddLensOperation(Label: "ab", FocalLength: 5), boxNumber: 3);
    pile.Apply(operation: new RemoveLensOperation(Label: "pc"), boxNumber: 3);

    var power = pile.TotalFocusingPower();

    var expectedPower = ((3 + 1) * 1 * 9) + ((3 + 1) * 2 * 5);
    Assert.Equal(expectedPower, power);
  }

  [Fact]
  public void TotalFocusingPowerAfterProvidedExampleOperations()
  {
    pile.Apply(operation: new AddLensOperation(Label: "rn", FocalLength: 1), boxNumber: 0);
    pile.Apply(operation: new RemoveLensOperation(Label: "cm"), boxNumber: 0);
    pile.Apply(operation: new AddLensOperation(Label: "qp", FocalLength: 3), boxNumber: 1);
    pile.Apply(operation: new AddLensOperation(Label: "cm", FocalLength: 2), boxNumber: 0);
    pile.Apply(operation: new RemoveLensOperation(Label: "qp"), boxNumber: 1);
    pile.Apply(operation: new AddLensOperation(Label: "pc", FocalLength: 4), boxNumber: 3);
    pile.Apply(operation: new AddLensOperation(Label: "ot", FocalLength: 9), boxNumber: 3);
    pile.Apply(operation: new AddLensOperation(Label: "ab", FocalLength: 5), boxNumber: 3);
    pile.Apply(operation: new RemoveLensOperation(Label: "pc"), boxNumber: 3);
    pile.Apply(operation: new AddLensOperation(Label: "pc", FocalLength: 6), boxNumber: 3);
    pile.Apply(operation: new AddLensOperation(Label: "ot", FocalLength: 7), boxNumber: 3);

    var power = pile.TotalFocusingPower();

    var expectedPower =
      ((0 + 1) * 1 * 1) +
      ((0 + 1) * 2 * 2) +
      ((3 + 1) * 1 * 7) +
      ((3 + 1) * 2 * 5) +
      ((3 + 1) * 3 * 6);
    Assert.Equal(expectedPower, power);
  }

}