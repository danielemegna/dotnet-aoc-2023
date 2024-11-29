namespace aoc2023.day18;

public class LagoonGround
{
  private int dugOutCubicMeters;

  public LagoonGround()
  {
    this.dugOutCubicMeters = 1;
  }

  public int DugOutCubicMeters()
  {
    return this.dugOutCubicMeters;
  }

  public void process(DigPlanInstruction instruction)
  {
    this.dugOutCubicMeters++;
  }
}
