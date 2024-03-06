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

    [Fact]
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

    [Fact]
    public void CheckInsideTheLoop()
    {
      Assert.True(gun.IsInsideTheLoop(new Coordinate(2, 2)));
    }

  }

  public class WithVeryComplexMap
  {
    private RayCastingGun gun = new(
      GardenMap.From(SolverTest.VERY_COMPLEX_PROVIDED_EXAMPLE_INPUT_LINES)
    );

    [Fact]
    public void CheckGroundOutsideTheLoop()
    {
      Assert.False(gun.IsInsideTheLoop(new Coordinate(1, 8)));
      Assert.False(gun.IsInsideTheLoop(new Coordinate(18, 10)));
    }

    [Fact]
    public void CheckPipePartOfTheLoopBoundary()
    {
      Assert.False(gun.IsInsideTheLoop(new Coordinate(9, 4)));
    }

    [Fact(Skip = "WIP")]
    public void CheckGroundInsideTheLoop()
    {
      Assert.True(gun.IsInsideTheLoop(new Coordinate(10, 4)));
    }

    [Fact(Skip = "WIP")]
    public void CheckPipeInsideTheLoop()
    {
      Assert.True(gun.IsInsideTheLoop(new Coordinate(12, 5)));
      Assert.True(gun.IsInsideTheLoop(new Coordinate(13, 4)));
      Assert.True(gun.IsInsideTheLoop(new Coordinate(14, 3)));
    }

  }

}
