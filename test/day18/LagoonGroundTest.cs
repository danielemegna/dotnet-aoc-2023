namespace aoc2023.day18;

using Xunit;

public class LagoonGroundTest
{

  [Fact]
  public void LagoonGroundHasFirstCubicMeterDugOutByDefault()
  {
    var ground = new LagoonGround();
    Assert.Equal(1, ground.DugOutCubicMeters());
  }

  [Fact]
  public void GetDugOutCubicMetersAfterSingleDigPlanInstruction()
  {
    var ground = new LagoonGround();

    var instruction = new DigPlanInstruction(InstructionDirection.RIGHT, 1);
    ground.process(instruction);

    Assert.Equal(2, ground.DugOutCubicMeters());
  }

}
