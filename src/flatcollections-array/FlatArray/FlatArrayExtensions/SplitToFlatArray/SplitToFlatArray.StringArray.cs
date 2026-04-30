namespace System;

partial class FlatArrayExtensions
{
    public static FlatArray<string> SplitToFlatArray(
        this string? source, string[]? separators, StringSplitOptions options = StringSplitOptions.None)
    {
        if (source is null)
        {
            return default;
        }

        var array = source.Split(separators, options);
        if (array.Length is 0)
        {
            return default;
        }

        return new(array.Length, array);
    }

    public static FlatArray<string> SplitToFlatArray(
        this string? source, string[]? separators, int count, StringSplitOptions options = StringSplitOptions.None)
    {
        if (source is null || count <= 0)
        {
            return default;
        }

        var array = source.Split(separators, count, options);
        if (array.Length is 0)
        {
            return default;
        }

        return new(array.Length, array);
    }
}