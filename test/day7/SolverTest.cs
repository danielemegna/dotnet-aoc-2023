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
    public void ParseProvidingExample()
    {
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
    public void SortProvidedExampleByHandsRank()
    {
      Bet[] bets = [
        new Bet(CardsHand.From("32T3K"), 123),
        new Bet(CardsHand.From("T55J5"), 234),
        new Bet(CardsHand.From("KK677"), 345),
        new Bet(CardsHand.From("KTJJT"), 456),
        new Bet(CardsHand.From("QQQJA"), 567)
      ];

      solver.SortBetsByHandsRank(ref bets);

      Bet[] expected = [
        new Bet(CardsHand.From("32T3K"), 123),
        new Bet(CardsHand.From("KTJJT"), 456),
        new Bet(CardsHand.From("KK677"), 345),
        new Bet(CardsHand.From("T55J5"), 234),
        new Bet(CardsHand.From("QQQJA"), 567)
      ];
      Assert.Equal(expected, bets);
    }

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.TotalWinningsOfHands(PROVIDED_EXAMPLE_INPUT_LINES);
      Assert.Equal(765 * 1 + 220 * 2 + 28 * 3 + 684 * 4 + 483 * 5, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day7/input.txt");
      var actual = solver.TotalWinningsOfHands(input);
      Assert.Equal(250898830, actual);
    }
  }

}
