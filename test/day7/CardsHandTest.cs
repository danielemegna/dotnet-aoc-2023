namespace aoc2023.day7;

using Xunit;

public class CardsHandTest {

  [Fact]
  public void RecognizeHandType() {
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

  [Fact]
  public void CannotBuildCardsHandWithMoreOrLessThanFiveCards() {
    Assert.Throws<CardsHandBuildException>(() => new CardsHand(Card.THREE));
    Assert.Throws<CardsHandBuildException>(() => new CardsHand());
    Assert.Throws<CardsHandBuildException>(() => new CardsHand(Card.THREE, Card.ACE, Card.QUEEN, Card.SEVEN));
    Assert.Throws<CardsHandBuildException>(() =>
      new CardsHand(Card.THREE, Card.ACE, Card.QUEEN, Card.SEVEN, Card.ACE, Card.JACK)
    );
  }

  [Fact]
  public void Equality() {
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
