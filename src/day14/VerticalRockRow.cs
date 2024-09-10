using System.Collections;

namespace aoc2023.day14;

class VerticalRockRow
{
    private MapObject[] rowObjects;

    public VerticalRockRow(MapObject[] rowObjects)
    {
        this.rowObjects = rowObjects;
    }

    public void Tilt()
    {

    }

    public override bool Equals(object? other)
    {
        if (this == other) return true;
        if (other is null) return false;
        if (other.GetType() != typeof(VerticalRockRow)) return false;
        var otherCasted = (VerticalRockRow)other;

        return StructuralComparisons.StructuralEqualityComparer.Equals(rowObjects, otherCasted.rowObjects);
    }

    public override int GetHashCode() =>
      StructuralComparisons.StructuralEqualityComparer.GetHashCode(rowObjects);
}
