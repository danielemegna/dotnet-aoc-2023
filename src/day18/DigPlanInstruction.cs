namespace aoc2023.day18;

public record DigPlanInstruction(InstructionDirection Direction, int StepSize)
{
  public static DigPlanInstruction From(string stringValue)
  {
    string[] instructionParts = stringValue.Split(" ");

    var direction = InstructionDirectionFrom(instructionParts[0][0]);
    var stepSize = int.Parse(instructionParts[1]);
    return new DigPlanInstruction(direction, stepSize);
  }

  private static InstructionDirection InstructionDirectionFrom(char character)
  {
    return character switch
    {
      'R' => InstructionDirection.RIGHT,
      'L' => InstructionDirection.LEFT,
      'D' => InstructionDirection.DOWN,
      'U' => InstructionDirection.UP,
      _ => throw new ArgumentException($"Not existing instruction direction [{character}]"),
    };
  }

  public override string ToString() => $"{this.Direction} {this.StepSize}";
}

public enum InstructionDirection { RIGHT, DOWN, LEFT, UP }
