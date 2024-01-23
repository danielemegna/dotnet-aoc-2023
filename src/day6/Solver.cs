namespace aoc2023.day6;

public class Solver
{

  public int WinsFactor(string[] inputLines)
  {
    throw new NotImplementedException();
  }

  internal Race[] ParseRaces(string[] inputLines)
  {
    var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
    var firstLineParts = inputLines[0].Split(" ", stringSplitOptions);
    var secondLineParts = inputLines[1].Split(" ", stringSplitOptions);

    return firstLineParts.Skip(1).Select((raceDurationInMilliseconds, raceIndex) => {
      return new Race(
        DurationInMilliseconds: int.Parse(raceDurationInMilliseconds),
        RecordInMillimeters: int.Parse(secondLineParts[raceIndex + 1])
      );

    }).ToArray();
  }

}