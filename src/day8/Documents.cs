namespace aoc2023.day8;

public record Documents(Move[] Moves, Dictionary<int, (int, int)> NetworkMap);

public enum Move { LEFT, RIGHT }