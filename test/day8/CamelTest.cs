namespace aoc2023.day8;

using Xunit;

public class CamelTest
{
  private readonly Dictionary<int, (int, int)> aNetwork = new() {
    { 0,      (10000,  232323) },
    { 10000,  (232323, 250000) },
    { 250000, (10000,  232323) },
    { 101,    (10101,  232323) },
    { 10101,  (20101,  20101)  },
    { 20101,  (250101, 250101) },
    { 250101, (10101,  10101)  },
    { 232323, (232323, 232323) }
  };

  [Fact]
  public void CamelReachDestinationAfterTwoMoves()
  {
    var camel = new Camel(0, aNetwork);
    camel.Move(Move.LEFT);
    Assert.False(camel.IsDestinationReached());
    camel.Move(Move.RIGHT);
    Assert.True(camel.IsDestinationReached());
  }

  [Fact]
  public void CamelReachDestinationAfterThreeMoves()
  {
    var camel = new Camel(101, aNetwork);
    camel.Move(Move.LEFT);
    Assert.False(camel.IsDestinationReached());
    camel.Move(Move.RIGHT);
    Assert.False(camel.IsDestinationReached());
    camel.Move(Move.LEFT);
    Assert.True(camel.IsDestinationReached());
  }

  [Fact]
  public void GetTheTwoWalkedStepsToReachDestinationWithMoves()
  {
    var camel = new Camel(0, aNetwork);
    var actual = camel.WalkedStepsToReachDestinationWith([Move.LEFT, Move.RIGHT]);
    Assert.Equal(2, actual);
  }

  [Fact]
  public void GetTheThreeWalkedStepsToReachDestinationWithMoves()
  {
    var camel = new Camel(101, aNetwork);
    var actual = camel.WalkedStepsToReachDestinationWith([Move.LEFT, Move.RIGHT]);
    Assert.Equal(3, actual);
  }

}