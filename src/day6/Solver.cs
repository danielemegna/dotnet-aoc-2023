namespace aoc2023.day6;

public class Solver
{

  public int WaysToWinFactor(string[] inputLines)
  {
    var races = ParseRaces(inputLines);
    return races.Select(WaysToWinCount).Aggregate((a, b) => a * b);
  }

  public int WaysToWinCount(string[] inputLines)
  {
    var race = ParseAsSingleRace(inputLines);
    return WaysToWinCount(race);
  }

  internal Race[] ParseRaces(string[] inputLines)
  {
    var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
    var firstLineParts = inputLines[0].Split(" ", stringSplitOptions);
    var secondLineParts = inputLines[1].Split(" ", stringSplitOptions);

    return firstLineParts.Skip(1).Select((raceDurationInMilliseconds, raceIndex) =>
    {
      return new Race(
        DurationInMilliseconds: long.Parse(raceDurationInMilliseconds),
        RecordInMillimeters: long.Parse(secondLineParts[raceIndex + 1])
      );

    }).ToArray();
  }

  internal Race ParseAsSingleRace(string[] inputLines)
  {
    var raceDurationString = string.Join("", inputLines[0].Split(" ").Skip(1));
    var raceRecordString = string.Join("", inputLines[1].Split(" ").Skip(1));
    return new Race(
        DurationInMilliseconds: long.Parse(raceDurationString),
        RecordInMillimeters: long.Parse(raceRecordString)
    );
  }

  internal int WaysToWinCount(Race race)
  {
    var wins = 0;
    var toyBoat = new ToyBoat();
    for (long chargeTimeAttempt = 1; chargeTimeAttempt < race.DurationInMilliseconds - 1; chargeTimeAttempt++)
    {
      toyBoat.ChargeFor(chargeTimeAttempt);
      var reachedDistance = toyBoat.DistanceAfter(race.DurationInMilliseconds);
      if (reachedDistance > race.RecordInMillimeters)
      {
        wins++;
        continue;
      }

      if (chargeTimeAttempt > race.DurationInMilliseconds / 2)
        break;
    }
    return wins;
  }

}