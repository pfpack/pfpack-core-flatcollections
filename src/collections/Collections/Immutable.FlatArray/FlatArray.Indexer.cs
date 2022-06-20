using System.Runtime.CompilerServices;

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    public T this[int index]
        =>
        items[InnerValidateIndex(index)];

    private int InnerValidateIndex(int index, [CallerArgumentExpression("index")] string? paramName = null)
        =>
        index >= 0 && index < items.Length ? index : throw InnerUnexpectedIndexValueException(paramName, index);

    private static ArgumentOutOfRangeException InnerUnexpectedIndexValueException(string? paramName, int index)
        =>
        new(paramName, index, "The index must be greater than or equal to zero and less than the array length.");
}
