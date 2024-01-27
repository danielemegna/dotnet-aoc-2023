namespace aoc2023.day7;

using Xunit;

public class SolverTest
{
  public static readonly string[] PROVIDED_EXAMPLE_INPUT_LINES = [
    "32T3K 765",
    "T55J5 684",
    "KK677 28",
    "KTJJT 220",
    "QQQJA 483"
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void ParseProvidingExample() {
      Bet[] actual = solver.ParseBetList(PROVIDED_EXAMPLE_INPUT_LINES);
      Bet[] expected = [
        new Bet(Hand: new CardsHand(Card.THREE, Card.TWO, Card.TEN, Card.THREE, Card.KING), Amount: 765),
        new Bet(Hand: new CardsHand(Card.TEN, Card.FIVE, Card.FIVE, Card.JACK, Card.FIVE), Amount: 684),
        new Bet(Hand: new CardsHand(Card.KING, Card.KING, Card.SIX, Card.SEVEN, Card.SEVEN), Amount: 28),
        new Bet(Hand: new CardsHand(Card.KING, Card.TEN, Card.JACK, Card.JACK, Card.TEN), Amount: 220),
        new Bet(Hand: new CardsHand(Card.QUEEN, Card.QUEEN, Card.QUEEN, Card.JACK, Card.ACE), Amount: 483),
      ];
      Assert.Equal(expected, actual);
    }

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
