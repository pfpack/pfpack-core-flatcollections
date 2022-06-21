namespace System.Collections.Immutable;

partial class FlatArray
{
    public static bool Equals<T>(FlatArray<T>? left, FlatArray<T>? right)
        =>
        FlatArray<T>.Equals(left, right);
}
