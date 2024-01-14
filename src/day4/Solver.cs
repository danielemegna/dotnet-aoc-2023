namespace aoc2023.day4;

public class Solver
{
  public int SumPointsOfScratchcards(string[] input)
  {
    throw new NotImplementedException();
  }

  internal Scratchcard[] ParseScratchcards(string[] inputLines)
  {
    return inputLines.Select(line => {
      var cardContentString = line.Split(":")[1];
      var splitOptions = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;
      var (winningNumbersString, cardNumbersString) = cardContentString.Split("|") switch { var a => (a[0], a[1]) };

      var winningNumbers = winningNumbersString.Split(" ", splitOptions).Select(int.Parse);
      var cardNumbers = cardNumbersString.Split(" ", splitOptions).Select(int.Parse);
      return new Scratchcard(winningNumbers, cardNumbers);
    }).ToArray();
  }

}