namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<string> SplitToFlatArray(
        this string? source, string? separator, StringSplitOptions options = StringSplitOptions.None)
    {
        if (source is null)
        {
            return default;
        }

        var array = source.Split(separator, options);
        if (array.Length is 0)
        {
            return default;
        }

        return new(array.Length, array);
    }

    public static FlatArray<string> SplitToFlatArray(
        this string? source, string? separator, int count, StringSplitOptions options = StringSplitOptions.None)
    {
        if (source is null || count <= 0)
        {
            return default;
        }

        var array = source.Split(separator, count, options);
        if (array.Length is 0)
        {
            return default;
        }

        return new(array.Length, array);
    }
}