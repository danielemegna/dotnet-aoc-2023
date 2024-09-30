namespace aoc2023.day15;

public class HolidayASCIIStringHelper
{
  public int HashCodeOf(string value)
  {
    int cursorValue = 0;
    foreach (char character in value)
      cursorValue = HashCodeFor(character, cursorValue);

    return cursorValue;
  }

  private int HashCodeFor(char character, int startingValue)
  {
    int asciiCodeValue = (int)character;
    return ((startingValue + asciiCodeValue) * 17) % 256;
  }
}
