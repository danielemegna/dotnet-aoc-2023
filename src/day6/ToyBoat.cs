namespace aoc2023.day6;

public class ToyBoat
{
  private long chargeTimeInMilliseconds = 0;

  public void ChargeFor(long milliseconds)
  {
    chargeTimeInMilliseconds = milliseconds;
  }

  public long DistanceAfter(long milliseconds)
  {
    return (milliseconds - chargeTimeInMilliseconds) * chargeTimeInMilliseconds;
  }
}