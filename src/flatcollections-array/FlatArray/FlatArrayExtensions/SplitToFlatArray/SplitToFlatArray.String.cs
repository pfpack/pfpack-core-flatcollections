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

        return FlatArray<string>.InternalCreateOrDefault(array);
    }

    public static FlatArray<string> SplitToFlatArray(
        this string? source, string? separator, int count, StringSplitOptions options = StringSplitOptions.None)
    {
        if (source is null || count <= 0)
        {
            return default;
        }

        var array = source.Split(separator, count, options);

        return FlatArray<string>.InternalCreateOrDefault(array);
    }
}