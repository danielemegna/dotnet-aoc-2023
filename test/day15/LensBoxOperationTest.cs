namespace aoc2023.day15;

using Xunit;

public class LensBoxOperationTest
{

  [Fact]
  public void BuildAnAddLensOperationFromString()
  {
    var operation = LensBoxOperation.BuildFrom("cm=5");

    Assert.IsType<AddLensOperation>(operation);
    Assert.Equal("cm", operation.GetLabel());
    Assert.Equal(5, operation.GetFocalLength());

    operation = LensBoxOperation.BuildFrom("rn=3");

    Assert.IsType<AddLensOperation>(operation);
    Assert.Equal("rn", operation.GetLabel());
    Assert.Equal(3, operation.GetFocalLength());
  }

  [Fact]
  public void BuildARemoveLensOperationFromString()
  {
    var operation = LensBoxOperation.BuildFrom("cm-");

    Assert.IsType<RemoveLensOperation>(operation);
    Assert.Equal("cm", operation.GetLabel());
    Assert.Null(operation.GetFocalLength());

    operation = LensBoxOperation.BuildFrom("rn-");

    Assert.IsType<RemoveLensOperation>(operation);
    Assert.Equal("rn", operation.GetLabel());
    Assert.Null(operation.GetFocalLength());
  }

}
