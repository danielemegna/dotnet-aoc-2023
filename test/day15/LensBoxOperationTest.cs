namespace aoc2023.day15;

using Xunit;

public class LensBoxOperationTest
{

  [Fact]
  public void BuildAnAddLensOperationFromString()
  {
    var operation = LensBoxOperation.Build("cm=5");

    Assert.IsType<AddLensOperation>(operation);
    Assert.Equal("cm", operation.GetLabel());
    Assert.Equal(5, operation.GetFocalLength());

    operation = LensBoxOperation.Build("rn=3");

    Assert.IsType<AddLensOperation>(operation);
    Assert.Equal("rn", operation.GetLabel());
    Assert.Equal(3, operation.GetFocalLength());
  }

}
