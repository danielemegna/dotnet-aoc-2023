namespace aoc2023.day8;

using Xunit;

public class CamelTest
{
  private readonly Dictionary<int, (int, int)> firstExampleNetwork = new() {
    { 0,      (10101,  20202) },
    { 10101,  (30303,  40404) },
    { 20202,  (252525, 60606) },
    { 30303,  (30303,  30303) },
    { 40404,  (40404,  40404) },
    { 60606,  (60606,  60606) },
    { 252525, (252525, 252525) },
  };

  private readonly Dictionary<int, (int, int)> secondExampleNetwork = new() {
    { 0,      (10101,  10101) },
    { 10101,  (0,      252525) },
    { 252525, (252525, 252525) },
  };

  private readonly Dictionary<int, (int, int)> thirdExampleNetwork = new() {
    { 0,      (10000,  232323) },
    { 10000,  (232323, 250000) },
    { 250000, (10000,  232323) },
    { 101,    (10101,  232323) },
    { 10101,  (20101,  20101)  },
    { 20101,  (250101, 250101) },
    { 250101, (10101,  10101)  },
    { 232323, (232323, 232323) }
  };

  public class MoveAndReachDestination : CamelTest
  {

    [Fact]
    public void CamelReachDestinationAfterTwoMoves()
    {
      var camel = new Camel(0, thirdExampleNetwork);
      camel.Move(Move.LEFT);
      Assert.False(camel.IsDestinationReached());
      camel.Move(Move.RIGHT);
      Assert.True(camel.IsDestinationReached());
    }

    [Fact]
    public void CamelReachDestinationAfterThreeMoves()
    {
      var camel = new Camel(101, thirdExampleNetwork);
      camel.Move(Move.LEFT);
      Assert.False(camel.IsDestinationReached());
      camel.Move(Move.RIGHT);
      Assert.False(camel.IsDestinationReached());
      camel.Move(Move.LEFT);
      Assert.True(camel.IsDestinationReached());
    }

  }

  public class GetWalkedStepsToReachDestinationWithMoves : CamelTest
  {

    [Fact]
    public void OnFirstNetwork()
    {
      var camel = new Camel(0, firstExampleNetwork);
      var actual = camel.WalkedStepsToReachDestinationWith([Move.RIGHT, Move.LEFT]);
      Assert.Equal(2, actual);
    }

    [Fact]
    public void OnSecondNetwork()
    {
      var camel = new Camel(0, secondExampleNetwork);
      var actual = camel.WalkedStepsToReachDestinationWith([Move.LEFT, Move.LEFT, Move.RIGHT]);
      Assert.Equal(6, actual);
    }

    [Fact]
    public void OnThirdNetworkWithFirstStartingPoint()
    {
      var camel = new Camel(0, thirdExampleNetwork);
      var actual = camel.WalkedStepsToReachDestinationWith([Move.LEFT, Move.RIGHT]);
      Assert.Equal(2, actual);
    }

    [Fact]
    public void OnThirdNetworkWithSecondStartingPoint()
    {
      var camel = new Camel(101, thirdExampleNetwork);
      var actual = camel.WalkedStepsToReachDestinationWith([Move.LEFT, Move.RIGHT]);
      Assert.Equal(3, actual);
    }

  }

}