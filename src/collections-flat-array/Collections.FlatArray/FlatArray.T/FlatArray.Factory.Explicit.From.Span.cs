namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public static FlatArray<T> From(ReadOnlySpan<T> source)
    {
        var count = source.Length;
        if (count is not > 0)
        {
            return InnerEmptyFlatArray.Value;
        }

        var array = new T[count];
        source.CopyTo(new Span<T>(array));

        // Clone for the safety purposes
        return new(InnerCloneArray(array), default);
    }

    public static FlatArray<T> From(Span<T> source)
    {
        var count = source.Length;
        if (count is not > 0)
        {
            return InnerEmptyFlatArray.Value;
        }

        var array = new T[count];
        source.CopyTo(new Span<T>(array));

        // Clone for the safety purposes
        return new(InnerCloneArray(array), default);
    }
    // An alternative implementation:
    // =>
    // From((ReadOnlySpan<T>)source);
}
