namespace aoc2023.day18;

using Xunit;

public class DigPlanInstructionTest
{

  public static readonly IEnumerable<object[]> TestCases = [
    ["R 6 (#70c710)", new DigPlanInstruction(Direction: InstructionDirection.RIGHT, StepSize: 6)],
    ["D 5 (#0dc571)", new DigPlanInstruction(Direction: InstructionDirection.DOWN, StepSize: 5)],
    ["L 2 (#5713f0)", new DigPlanInstruction(Direction: InstructionDirection.LEFT, StepSize: 2)],
    ["U 3 (#a77fa3)", new DigPlanInstruction(Direction: InstructionDirection.UP, StepSize: 3)]
  ];

  [Theory]
  [MemberData(nameof(TestCases))]
  public void BuildInstructionPlanFromStringInRightDirection(string stringValue, DigPlanInstruction expected)
  {
    var actual = DigPlanInstruction.From(stringValue);
    Assert.Equal(actual, expected);
  }

}
