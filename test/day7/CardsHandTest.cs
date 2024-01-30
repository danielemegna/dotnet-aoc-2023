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

    Assert.Equal(HandType.HIGH_CARD, highCard.HandType);
    Assert.Equal(HandType.ONE_PAIR, onePair.HandType);
    Assert.Equal(HandType.TWO_PAIR, twoPair.HandType);
    Assert.Equal(HandType.THREE_OF_A_KIND, threeOfAKind.HandType);
    Assert.Equal(HandType.FULL_HOUSE, fullHouse.HandType);
    Assert.Equal(HandType.FOUR_OF_A_KIND, fourOfAKind.HandType);
    Assert.Equal(HandType.FIVE_OF_A_KIND, fiveOfAKind.HandType);
  }

  [Fact]
  public void RecognizeHandTypeWithJoker()
  {
    var onePair = new CardsHand(Card.TEN, Card.JOKER, Card.ACE, Card.FIVE, Card.TWO);
    var threeOfAKind = new CardsHand(Card.TEN, Card.TEN, Card.JOKER, Card.FIVE, Card.TWO);
    var fullHouse = new CardsHand(Card.TEN, Card.TEN, Card.JOKER, Card.FIVE, Card.FIVE);
    var fourOfAKind = new CardsHand(Card.TEN, Card.TEN, Card.TEN, Card.JOKER, Card.FIVE);
    var fiveOfAKind = new CardsHand(Card.TEN, Card.TEN, Card.TEN, Card.TEN, Card.JOKER);
    var fourJokers = new CardsHand(Card.TEN, Card.TEN, Card.TEN, Card.TEN, Card.JOKER);
    var fiveJokers = new CardsHand(Card.JOKER, Card.JOKER, Card.JOKER, Card.JOKER, Card.JOKER);

    Assert.Equal(HandType.ONE_PAIR, onePair.HandType);
    Assert.Equal(HandType.THREE_OF_A_KIND, threeOfAKind.HandType);
    Assert.Equal(HandType.FULL_HOUSE, fullHouse.HandType);
    Assert.Equal(HandType.FOUR_OF_A_KIND, fourOfAKind.HandType);
    Assert.Equal(HandType.FIVE_OF_A_KIND, fiveOfAKind.HandType);
    Assert.Equal(HandType.FIVE_OF_A_KIND, fourJokers.HandType);
    Assert.Equal(HandType.FIVE_OF_A_KIND, fiveJokers.HandType);
  }

  public class Comparison()
  {

    [Fact]
    public void ComparingSameHands()
    {
      Card[] randomCards = GetFiveRandomCards();
      var hand1 = new CardsHand(randomCards);
      var hand2 = new CardsHand((Card[])randomCards.Clone());
      Assert.False(hand1 > hand2);
      Assert.False(hand1 < hand2);
      Assert.False(hand2 > hand1);
      Assert.False(hand2 < hand1);
      Assert.Equal(0, hand1.CompareTo(hand2));
      Assert.Equal(0, hand2.CompareTo(hand1));
    }

    [Fact]
    public void OnePairAlwaysBetterThanAnHighCard()
    {
      var onePair = CardsHand.From("22345");
      var highCard = CardsHand.From("AKQJT");
      AssertFirstBetterThanSecond(onePair, highCard);
    }

    [Fact]
    public void TwoPairAlwaysBetterThanOnePair()
    {
      var twoPair = CardsHand.From("22334");
      var onePair = CardsHand.From("AAKQJ");
      AssertFirstBetterThanSecond(twoPair, onePair);
    }

    [Fact]
    public void FullHouseAlwaysBetterThanThreeOfAKind()
    {
      var fullHouse = CardsHand.From("22233");
      var threeOfAKind = CardsHand.From("AAAKQ");
      AssertFirstBetterThanSecond(fullHouse, threeOfAKind);
    }

    [Fact]
    public void FiveOfAKindAlwaysBetterThanFourOfAKind()
    {
      var fiveOfAKind = CardsHand.From("22222");
      var fourOfAKind = CardsHand.From("AAAAK");
      AssertFirstBetterThanSecond(fiveOfAKind, fourOfAKind);
    }

    [Fact]
    public void OnSameKind_FirstCardMatters()
    {
      var highCardWithGreaterFirstCard = CardsHand.From("34567");
      var highCardWithLowerFirstCard = CardsHand.From("2AKQJ");
      AssertFirstBetterThanSecond(highCardWithGreaterFirstCard, highCardWithLowerFirstCard);

      var fullHouseWithGreaterFistCard = CardsHand.From("33444");
      var fullHouseWithLowerFirstCard = CardsHand.From("22AAA");
      AssertFirstBetterThanSecond(fullHouseWithGreaterFistCard, fullHouseWithLowerFirstCard);
    }

    [Fact]
    public void OnSameKindAndSameFirstTwo_ThirdCardMatters()
    {
      var highCardWithGreaterThirdCard = CardsHand.From("AK345");
      var highCardWithLowerThirdCard = CardsHand.From("AK2QJ");
      AssertFirstBetterThanSecond(highCardWithGreaterThirdCard, highCardWithLowerThirdCard);

      var twoPairsWithGreaterThirdCard = CardsHand.From("KK322");
      var twoPairsWithLowerThirdCard = CardsHand.From("KK2QQ");
      AssertFirstBetterThanSecond(twoPairsWithGreaterThirdCard, twoPairsWithLowerThirdCard);
    }

    [Fact]
    public void SomeMoreComparision()
    {
      AssertFirstBetterThanSecond(CardsHand.From("33332"), CardsHand.From("2AAAA"));
      AssertFirstBetterThanSecond(CardsHand.From("77888"), CardsHand.From("77788"));
      AssertFirstBetterThanSecond(CardsHand.From("KK677"), CardsHand.From("KTJJT"));
      AssertFirstBetterThanSecond(CardsHand.From("QQQJA"), CardsHand.From("T55J5"));
    }

    [Fact]
    public void JokerIsTheWeakestIndividualCard() {
      AssertFirstBetterThanSecond(CardsHand.From("22222", true), CardsHand.From("JJJJJ", true));
      AssertFirstBetterThanSecond(CardsHand.From("44442", true), CardsHand.From("JJQQ2", true));
      AssertFirstBetterThanSecond(CardsHand.From("QQQQ2", true), CardsHand.From("QJJQ2", true));
    }

    [Fact]
    public void SomeMoreComparisionWithJoker()
    {
      AssertFirstBetterThanSecond(CardsHand.From("KTJJT", true), CardsHand.From("QQQJA", true));
      AssertFirstBetterThanSecond(CardsHand.From("QQQJA", true), CardsHand.From("T55J5", true));
      AssertFirstBetterThanSecond(CardsHand.From("T55J5", true), CardsHand.From("KK677", true));
      AssertFirstBetterThanSecond(CardsHand.From("KK677", true), CardsHand.From("32T3K", true));
    }

    private static void AssertFirstBetterThanSecond(CardsHand first, CardsHand second)
    {
      Assert.True(first > second, $"{first} should be greater than {second}");
      Assert.False(first < second, $"{first} should not be lower than {second}");
      Assert.False(second > first, $"{second} should not be greater than {first}");
      Assert.True(second < first, $"{second} should be lower than {first}");
      Assert.Equal(1, first.CompareTo(second));
      Assert.Equal(-1, second.CompareTo(first));
    }

    private static Card[] GetFiveRandomCards()
    {
      var random = new Random();
      var kindsOfCard = Enum.GetValues<Card>();
      return Enumerable.Range(1, 5).Select((_) =>
      {
        int randomKindIndex = random.Next(kindsOfCard.Length);
        var randomCard = kindsOfCard.GetValue(randomKindIndex);
        return (Card)randomCard!;
      }).ToArray();
    }

    public class CompareTo
    {
      private CardsHand fiveOfAKind = CardsHand.From("AAAAA");
      private CardsHand fullHouse = CardsHand.From("AAAKK");
      private CardsHand onePair = CardsHand.From("22345");
      private CardsHand highHand = CardsHand.From("23456");

      [Fact]
      public void ReturnsOneForBetterHands()
      {
        Assert.Equal(1, fiveOfAKind.CompareTo(fullHouse));
        Assert.Equal(1, fiveOfAKind.CompareTo(onePair));
        Assert.Equal(1, fiveOfAKind.CompareTo(highHand));
        Assert.Equal(1, fullHouse.CompareTo(onePair));
        Assert.Equal(1, fullHouse.CompareTo(highHand));
        Assert.Equal(1, onePair.CompareTo(highHand));
      }

      [Fact]
      public void ReturnsMinosOneForWorstHands()
      {
        Assert.Equal(-1, highHand.CompareTo(fiveOfAKind));
        Assert.Equal(-1, highHand.CompareTo(fullHouse));
        Assert.Equal(-1, highHand.CompareTo(onePair));
        Assert.Equal(-1, onePair.CompareTo(fiveOfAKind));
        Assert.Equal(-1, onePair.CompareTo(fullHouse));
        Assert.Equal(-1, fullHouse.CompareTo(fiveOfAKind));
      }

      [Fact]
      public void ReturnsZeroForSameHands()
      {
        Assert.Equal(0, fiveOfAKind.CompareTo(fiveOfAKind));
        Assert.Equal(0, highHand.CompareTo(highHand));
      }
    }
  }

  public class ParseAndBuild
  {

    [Fact]
    public void BuildFromString()
    {
      var hand = CardsHand.From("32TJK");
      var expected = new CardsHand(Card.THREE, Card.TWO, Card.TEN, Card.JACK, Card.KING);
      Assert.Equal(expected, hand);
    }

    [Fact]
    public void BuildFromStringUsingJoker()
    {
      var hand = CardsHand.From("32TJK", true);
      var expected = new CardsHand(Card.THREE, Card.TWO, Card.TEN, Card.JOKER, Card.KING);
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
