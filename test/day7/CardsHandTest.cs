namespace aoc2023.day7;

using Xunit;

public class CardsHandTest
{

  [Fact]
  public void RecognizeHandType()
  {
    var highCard = new CardsHand(Card.TEN, Card.FOUR, Card.ACE, Card.FIVE, Card.TWO);
    var onePair = new CardsHand(Card.TEN, Card.TEN, Card.ACE, Card.FIVE, Card.TWO);
    var twoPair = new CardsHand(Card.TEN, Card.TEN, Card.ACE, Card.FIVE, Card.FIVE);
    var threeOfAKind = new CardsHand(Card.TEN, Card.TEN, Card.TEN, Card.FIVE, Card.TWO);
    var fullHouse = new CardsHand(Card.TEN, Card.TEN, Card.TEN, Card.FIVE, Card.FIVE);
    var fourOfAKind = new CardsHand(Card.TEN, Card.TEN, Card.TEN, Card.TEN, Card.FIVE);
    var fiveOfAKind = new CardsHand(Card.TEN, Card.TEN, Card.TEN, Card.TEN, Card.TEN);

    Assert.Equal(HandType.HIGH_CARD, highCard.GetHandType());
    Assert.Equal(HandType.ONE_PAIR, onePair.GetHandType());
    Assert.Equal(HandType.TWO_PAIR, twoPair.GetHandType());
    Assert.Equal(HandType.THREE_OF_A_KIND, threeOfAKind.GetHandType());
    Assert.Equal(HandType.FULL_HOUSE, fullHouse.GetHandType());
    Assert.Equal(HandType.FOUR_OF_A_KIND, fourOfAKind.GetHandType());
    Assert.Equal(HandType.FIVE_OF_A_KIND, fiveOfAKind.GetHandType());
  }

  public class Compare()
  {

    [Fact]
    public void ComparingSameHands()
    {
      var hand1 = new CardsHand(Card.ACE, Card.KING, Card.QUEEN, Card.JACK, Card.TEN);
      var hand2 = new CardsHand(Card.ACE, Card.KING, Card.QUEEN, Card.JACK, Card.TEN);
      Assert.False(hand1 > hand2);
      Assert.False(hand1 < hand2);
      Assert.False(hand2 > hand1);
      Assert.False(hand2 < hand1);
    }

    [Fact]
    public void OnePairAlwaysBetterThanAnHighCard()
    {
      var highCard = new CardsHand(Card.ACE, Card.KING, Card.QUEEN, Card.JACK, Card.TEN);
      var onePair = new CardsHand(Card.TWO, Card.TWO, Card.THREE, Card.FOUR, Card.FIVE);
      AssertFirstBetterThanSecond(onePair, highCard);
    }

    [Fact]
    public void TwoPairAlwaysBetterThanOnePair()
    {
      var onePair = new CardsHand(Card.ACE, Card.ACE, Card.KING, Card.QUEEN, Card.JACK);
      var twoPair = new CardsHand(Card.TWO, Card.TWO, Card.THREE, Card.THREE, Card.FOUR);
      AssertFirstBetterThanSecond(twoPair, onePair);
    }

    private static void AssertFirstBetterThanSecond(CardsHand first, CardsHand second)
    {
      Assert.True(first > second, $"{first} should be greater than {second}");
      Assert.False(first < second, $"{first} should not be lower than {second}");
      Assert.False(second > first, $"{second} should not be greater than {first}");
      Assert.True(second < first, $"{second} should be lower than {first}");
    }

  }

  public class ParseAndBuild
  {

    [Fact]
    public void BuildFromString()
    {
      var hand = CardsHand.From("32T3K");
      var expected = new CardsHand(Card.THREE, Card.TWO, Card.TEN, Card.THREE, Card.KING);
      Assert.Equal(expected, hand);
    }

    [Fact]
    public void CannotBuildCardFromStringWithBadStringInput()
    {
      var ex = Assert.Throws<CardsHandBuildException>(() => CardsHand.From("WRONG"));
      Assert.Equal("Cannot build card from char [W]", ex.Message);
      ex = Assert.Throws<CardsHandBuildException>(() => CardsHand.From("43KQ"));
      Assert.Equal("Cannot build CardsHand with 4 elements", ex.Message);
      ex = Assert.Throws<CardsHandBuildException>(() => CardsHand.From(""));
      Assert.Equal("Cannot build CardsHand with 0 elements", ex.Message);
    }

    [Fact]
    public void CannotBuildCardsHandWithMoreOrLessThanFiveCards()
    {
      var ex = Assert.Throws<CardsHandBuildException>(() =>
        new CardsHand(Card.THREE, Card.ACE, Card.QUEEN, Card.SEVEN
      ));
      Assert.Equal("Cannot build CardsHand with 4 elements", ex.Message);

      ex = Assert.Throws<CardsHandBuildException>(() =>
        new CardsHand(Card.THREE, Card.ACE, Card.QUEEN, Card.SEVEN, Card.ACE, Card.JACK)
      );
      Assert.Equal("Cannot build CardsHand with 6 elements", ex.Message);

      Assert.Throws<CardsHandBuildException>(() => new CardsHand(Card.THREE));
      Assert.Throws<CardsHandBuildException>(() => new CardsHand());
    }

  }

  [Fact]
  public void ToStringValue()
  {
    var hand = new CardsHand(Card.THREE, Card.TWO, Card.TEN, Card.THREE, Card.KING);
    Assert.Equal("[THREE,TWO,TEN,THREE,KING]", hand.ToString());
  }

  [Fact]
  public void Equality()
  {
    var first = new CardsHand(Card.TEN, Card.TEN, Card.ACE, Card.FIVE, Card.FIVE);
    var second = new CardsHand(Card.TEN, Card.TEN, Card.FIVE, Card.FIVE, Card.ACE);
    var third = new CardsHand(Card.TEN, Card.TEN, Card.ACE, Card.FIVE, Card.FIVE);
    var fourth = new CardsHand(Card.TWO, Card.THREE, Card.FOUR, Card.KING, Card.QUEEN);

    Assert.NotEqual(first, second);
    Assert.False(first.Equals(second));
    Assert.False(first == second);
    Assert.NotEqual(first.GetHashCode(), second.GetHashCode());

    Assert.Equal(first, third);
    Assert.True(first.Equals(third));
    Assert.False(first == third);
    Assert.NotSame(first, third);
    Assert.Equal(first.GetHashCode(), third.GetHashCode());

    Assert.NotEqual(first, fourth);
    Assert.False(first.Equals(fourth));
    Assert.False(first == fourth);
    Assert.NotEqual(first.GetHashCode(), fourth.GetHashCode());

    Assert.Equal(first, first);
    Assert.True(first.Equals(first));
    Assert.Same(first, first);
    Assert.Equal(first.GetHashCode(), first.GetHashCode());
  }

}
