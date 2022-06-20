namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    private static class InnerArrayHelper
    {
        internal static T[] Copy(T[] source)
        {
            //var dest = new T[source.Length];
            //Array.Copy(source, dest, source.Length);
            //return dest;

            //var dest = new T[source.Length];
            //source.CopyTo(dest, 0);
            //return dest;

            return (T[])source.Clone();
        }
    }
}
