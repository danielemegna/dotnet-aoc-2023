namespace aoc2023.day7;

using System.Collections;

public class CardsHand
{
  private readonly Card[] cards;
  private readonly HandType handType;

  public CardsHand(params Card[] cards)
  {
    if (cards.Length != 5)
      throw new CardsHandBuildException($"Cannot build CardsHand with {cards.Length} elements");

    this.cards = cards;
    this.handType = HandTypeFor(cards);
  }

  public static CardsHand From(string stringValue)
  {
    var cards = stringValue
      .ToCharArray()
      .Select(cardFrom)
      .ToArray();

    return new CardsHand(cards);
  }

  private static Card cardFrom(char c)
  {
    switch (c)
    {
      case 'A': return Card.ACE;
      case 'K': return Card.KING;
      case 'Q': return Card.QUEEN;
      case 'J': return Card.JACK;
      case 'T': return Card.TEN;
      case '9': return Card.NINE;
      case '8': return Card.EIGHT;
      case '7': return Card.SEVEN;
      case '6': return Card.SIX;
      case '5': return Card.FIVE;
      case '4': return Card.FOUR;
      case '3': return Card.THREE;
      case '2': return Card.TWO;
      default: throw new CardsHandBuildException($"Cannot build card from char [{c}]");
    }
  }

  private static HandType HandTypeFor(Card[] cards)
  {
    var groupedCardsCount = cards.GroupBy(c => c).Select(g => g.Count());

    switch (groupedCardsCount.Count())
    {
      case 5: return HandType.HIGH_CARD;
      case 4: return HandType.ONE_PAIR;
      case 3:
        if (groupedCardsCount.Any(g => g == 3))
          return HandType.THREE_OF_A_KIND;
        return HandType.TWO_PAIR;

      case 2:
        if (groupedCardsCount.Any(g => g == 4))
          return HandType.FOUR_OF_A_KIND;
        return HandType.FULL_HOUSE;

      default: return HandType.FIVE_OF_A_KIND;
    }
  }

  public HandType GetHandType()
  {
    return this.handType;
  }

  public override bool Equals(object? other)
  {
    if (this == other) return true;
    if (other is null) return false;
    if (other.GetType() != typeof(CardsHand)) return false;
    var otherCasted = (CardsHand)other;

    return cards.SequenceEqual(otherCasted.cards);
  }

  public override int GetHashCode() =>
    StructuralComparisons.StructuralEqualityComparer.GetHashCode(cards);
}

public class CardsHandBuildException(string message) : Exception(message) { }

public enum Card
{
  ACE, KING, QUEEN, JACK,
  TEN, NINE, EIGHT, SEVEN,
  SIX, FIVE, FOUR, THREE, TWO
}

public enum HandType
{
  HIGH_CARD, ONE_PAIR, TWO_PAIR,
  THREE_OF_A_KIND, FULL_HOUSE,
  FOUR_OF_A_KIND, FIVE_OF_A_KIND
}