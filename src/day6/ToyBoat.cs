namespace aoc2023.day6;

public class ToyBoat
{
  private int chargeTimeInMilliseconds = 0;

  public void ChargeFor(int milliseconds)
  {
    chargeTimeInMilliseconds = milliseconds;
  }

  public int DistanceAfter(int milliseconds)
  {
    return (milliseconds - chargeTimeInMilliseconds) * chargeTimeInMilliseconds;
  }
}