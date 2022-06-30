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

        return new(array, default);
    }

    public static FlatArray<T> From(Span<T> source)
        =>
        From((ReadOnlySpan<T>)source);
}
