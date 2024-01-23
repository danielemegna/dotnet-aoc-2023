namespace aoc2023.day6;

public class Solver
{

  public int WinsFactor(string[] inputLines)
  {
    var races = ParseRaces(inputLines);

    return races.Select(race =>
    {
      var wins = 0;
      var toyBoat = new ToyBoat();
      for (int chargeTimeAttempt = 1; chargeTimeAttempt < race.DurationInMilliseconds - 1; chargeTimeAttempt++)
      {
        toyBoat.ChargeFor(chargeTimeAttempt); 
        var reachedDistance = toyBoat.DistanceAfter(race.DurationInMilliseconds);
        if(reachedDistance > race.RecordInMillimeters)
          wins++;
      }
      return wins;
    }).Aggregate((a, b) => a * b);
  }

  internal Race[] ParseRaces(string[] inputLines)
  {
    var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
    var firstLineParts = inputLines[0].Split(" ", stringSplitOptions);
    var secondLineParts = inputLines[1].Split(" ", stringSplitOptions);

    return firstLineParts.Skip(1).Select((raceDurationInMilliseconds, raceIndex) =>
    {
      return new Race(
        DurationInMilliseconds: int.Parse(raceDurationInMilliseconds),
        RecordInMillimeters: int.Parse(secondLineParts[raceIndex + 1])
      );

    }).ToArray();
  }

}