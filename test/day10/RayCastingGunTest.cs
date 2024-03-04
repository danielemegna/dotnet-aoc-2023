namespace aoc2023.day10;

using Xunit;

public class RayCastingGunTest
{

  public class WithSimpleMap
  {
    private RayCastingGun gun = new(GardenMapTest.simpleMap);

    [Fact]
    public void CheckOutsideTheLoop()
    {
      Assert.False(gun.IsInsideTheLoop(new Coordinate(0, 0)));
    }

    [Fact]
    public void CheckTheLoopBoundary()
    {
      Assert.False(gun.IsInsideTheLoop(new Coordinate(2, 3)));
    }

    [Fact(Skip = "WIP")]
    public void CheckInsideTheLoop()
    {
      Assert.True(gun.IsInsideTheLoop(new Coordinate(2, 2)));
    }

    [Fact]
    public void CheckOutsideTheGarden()
    {
      Assert.False(gun.IsInsideTheLoop(new Coordinate(-1, -1)));
      Assert.False(gun.IsInsideTheLoop(new Coordinate(99, 99)));
    }

  }

  public class WithComplexMap
  {
    private RayCastingGun gun = new(GardenMapTest.complexMap);

    [Fact]
    public void CheckOutsideTheLoop()
    {
      Assert.False(gun.IsInsideTheLoop(new Coordinate(4, 4)));
    }

    [Fact]
    public void CheckTheLoopBoundary()
    {
      Assert.False(gun.IsInsideTheLoop(new Coordinate(1, 2)));
    }

    [Fact(Skip = "WIP")]
    public void CheckInsideTheLoop()
    {
      Assert.True(gun.IsInsideTheLoop(new Coordinate(2, 2)));
    }

  }

}
