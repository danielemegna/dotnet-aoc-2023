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
        for (int currentObjectIndex = 1; currentObjectIndex < rowObjects.Length; currentObjectIndex++)
        {
            if (rowObjects[currentObjectIndex] != MapObject.ROUND_ROCK)
                continue;

            for (int fallIndex = currentObjectIndex - 1; fallIndex >= 0; fallIndex--)
            {
                if (rowObjects[fallIndex] != MapObject.EMPTY_SPACE)
                    break;

                rowObjects[fallIndex] = MapObject.ROUND_ROCK;
                rowObjects[fallIndex + 1] = MapObject.EMPTY_SPACE;
            }
        }
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
