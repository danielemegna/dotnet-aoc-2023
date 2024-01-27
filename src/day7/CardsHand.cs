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
      .Select(CardFrom)
      .ToArray();

    return new CardsHand(cards);
  }

  private static Card CardFrom(char character)
  {
    return character switch
    {
      'A' => Card.ACE,
      'K' => Card.KING,
      'Q' => Card.QUEEN,
      'J' => Card.JACK,
      'T' => Card.TEN,
      '9' => Card.NINE,
      '8' => Card.EIGHT,
      '7' => Card.SEVEN,
      '6' => Card.SIX,
      '5' => Card.FIVE,
      '4' => Card.FOUR,
      '3' => Card.THREE,
      '2' => Card.TWO,
      _ => throw new CardsHandBuildException($"Cannot build card from char [{character}]"),
    };
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

  public static bool operator >(CardsHand first, CardsHand second)
  {
    if (first.GetHandType() > second.GetHandType())
      return true;

    return false;
  }

  public static bool operator <(CardsHand first, CardsHand second) =>
    !first.Equals(second) && !(first > second);

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

  public override string ToString()
  {
    return "[" + string.Join(",", cards.Select(c => c.ToString())) + "]";
  }
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