namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    private static T[] InnerCopyArray(T[] source)
        =>
        (T[])source.Clone();
}
