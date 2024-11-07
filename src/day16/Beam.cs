namespace aoc2023.day16;

public record Beam(Coordinate Coordinate, BeamDirection Direction);

public enum BeamDirection { RIGHT, DOWN, UP, LEFT }
