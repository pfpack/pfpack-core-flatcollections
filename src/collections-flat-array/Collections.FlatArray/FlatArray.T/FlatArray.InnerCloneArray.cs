namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static T[] InnerCloneArray(T[] source)
    {
        var dest = new T[source.Length];
        Array.Copy(source, dest, source.Length);
        return dest;
    }
}
