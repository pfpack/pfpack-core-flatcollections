namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static T[] InnerCopyArray(T[] source)
        =>
        (T[])source.Clone();
}
