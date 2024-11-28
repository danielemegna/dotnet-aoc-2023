namespace aoc2023.day18;

using Xunit;

public class DigPlanParserTest
{

  private readonly DigPlanParser parser = new DigPlanParser();

  [Fact]
  public void ParseSingleInstructionPlan()
  {
    var planString = "R 6 (#70c710)";

    var actual = parser.Parse(planString);

    var expected = new DigPlanInstruction(
      Direction: InstructionDirection.RIGHT,
      StepSize: 6
    );
    Assert.Single(actual);
    Assert.Equal(actual.First(), expected);
  }

}
