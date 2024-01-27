namespace aoc2023.day7;

using Xunit;

public class SolverTest
{
  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void SortProvidedExampleCardsHands()
    {
      CardsHand[] cardsHands = [
        CardsHand.From("32T3K"),
        CardsHand.From("T55J5"),
        CardsHand.From("KK677"),
        CardsHand.From("KTJJT"),
        CardsHand.From("QQQJA")
      ];

      solver.SortCardsHandsByRank(ref cardsHands);

      CardsHand[] expected = [
        CardsHand.From("32T3K"),
        CardsHand.From("KTJJT"),
        CardsHand.From("KK677"),
        CardsHand.From("T55J5"),
        CardsHand.From("QQQJA")
      ];
      Assert.Equal(expected, cardsHands);
    }

  }

}