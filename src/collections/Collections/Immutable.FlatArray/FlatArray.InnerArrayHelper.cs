//#define array_copy_strategy_static
//#define array_copy_strategy_instance
#define array_copy_strategy_clone

namespace System.Collections.Immutable;

partial class FlatArray<T>
{
    private static class InnerArrayHelper
    {
        internal static T[] Copy(T[] source)
#if array_copy_strategy_static
        {
            var dest = new T[source.Length];
            Array.Copy(source, dest, source.Length);
            return dest;
        }
#elif array_copy_strategy_instance
        {
            var dest = new T[source.Length];
            source.CopyTo(dest, 0);
            return dest;
        }
#elif array_copy_strategy_clone
            =>
            (T[])source.Clone(); // Currently is faster
#endif
    }
}
