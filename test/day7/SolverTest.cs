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

  public static readonly string[] ANOTHER_EXAMPLE_INPUT_LINES = [
    "2345A 1",
    "Q2KJJ 13",
    "Q2Q2Q 19",
    "T3T3J 17",
    "T3Q33 11",
    "2345J 3",
    "J345A 2",
    "32T3K 5",
    "T55J5 29",
    "KK677 7",
    "KTJJT 34",
    "QQQJA 31",
    "JJJJJ 37",
    "JAAAA 43",
    "AAAAJ 59",
    "AAAAA 61",
    "2AAAA 23",
    "2JJJJ 53",
    "JJJJ2 41",
  ];

  private readonly Solver solver = new();

  public class FirstPartTest : SolverTest
  {

    [Fact]
    public void ParseProvidingExample()
    {
      Bet[] actual = solver.ParseBetList(PROVIDED_EXAMPLE_INPUT_LINES, GameMode.JACK);
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
      var actual = solver.TotalWinningsOfHands(PROVIDED_EXAMPLE_INPUT_LINES, GameMode.JACK);
      Assert.Equal(765 * 1 + 220 * 2 + 28 * 3 + 684 * 4 + 483 * 5, actual);
    }

    [Fact]
    public void SolveAnotherExample()
    {
      var actual = solver.TotalWinningsOfHands(ANOTHER_EXAMPLE_INPUT_LINES, GameMode.JACK);
      Assert.Equal(6592, actual);
    }

    [Fact]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day7/input.txt");
      var actual = solver.TotalWinningsOfHands(input, GameMode.JACK);
      Assert.Equal(250898830, actual);
    }
  }

  public class SecondPartTest : SolverTest
  {

    [Fact]
    public void SolveTheProvidedExample()
    {
      var actual = solver.TotalWinningsOfHands(PROVIDED_EXAMPLE_INPUT_LINES, GameMode.JOKER);
      Assert.Equal(765 * 1 + 28 * 2 + 684 * 3 + 483 * 4 + 220 * 5, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveAnotherExample()
    {
      var actual = solver.TotalWinningsOfHands(ANOTHER_EXAMPLE_INPUT_LINES, GameMode.JOKER);
      Assert.Equal(6839, actual);
    }

    [Fact(Skip = "WIP")]
    public void SolveWithFile()
    {
      var input = File.ReadAllLines("day7/input.txt");
      var actual = solver.TotalWinningsOfHands(input, GameMode.JOKER);
      Assert.Equal(-1, actual);
    }
  }

}
