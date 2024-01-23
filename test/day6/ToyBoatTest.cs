namespace aoc2023.day6;

using Xunit;

public class ToyBoatTest
{

  [Fact]
  public void ZeroMillimetersWithoutCharging()
  {
    var boat = new ToyBoat();

    boat.ChargeFor(0);

    Assert.Equal(0, boat.DistanceAfter(1));
    Assert.Equal(0, boat.DistanceAfter(7));
    Assert.Equal(0, boat.DistanceAfter(999));
  }

  [Fact]
  public void SixMillimetersAfterSevenMsChargingOneMs()
  {
    var boat = new ToyBoat();

    boat.ChargeFor(1);

    Assert.Equal(6, boat.DistanceAfter(7));
  }

  [Fact]
  public void TenMillimetersAfterSevenMsChargingTwoMs()
  {
    var boat = new ToyBoat();

    boat.ChargeFor(2);

    Assert.Equal(10, boat.DistanceAfter(7));
  }

  [Fact]
  public void TwelveMillimetersAfterSevenMsChargingFourMs()
  {
    var boat = new ToyBoat();

    boat.ChargeFor(4);

    Assert.Equal(12, boat.DistanceAfter(7));
  }

  [Fact]
  public void SixMillimetersAfterSevenMsChargingSixMs()
  {
    var boat = new ToyBoat();

    boat.ChargeFor(6);

    Assert.Equal(6, boat.DistanceAfter(7));
  }

  [Fact]
  public void ZeroMillimetersAfterSevenMsChargingSevenMs()
  {
    var boat = new ToyBoat();

    boat.ChargeFor(7);

    Assert.Equal(0, boat.DistanceAfter(7));
  }

}
