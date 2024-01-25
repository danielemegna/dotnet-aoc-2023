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
  public void cannotBuildCardsHandWithMoreOrLessThanFiveCards() {
    Assert.Throws<CardsHandBuildException>(() => new CardsHand(Card.THREE));
    Assert.Throws<CardsHandBuildException>(() => new CardsHand());
    Assert.Throws<CardsHandBuildException>(() => new CardsHand(Card.THREE, Card.ACE, Card.QUEEN, Card.SEVEN));
    Assert.Throws<CardsHandBuildException>(() =>
      new CardsHand(Card.THREE, Card.ACE, Card.QUEEN, Card.SEVEN, Card.ACE, Card.JACK)
    );
  }

}
