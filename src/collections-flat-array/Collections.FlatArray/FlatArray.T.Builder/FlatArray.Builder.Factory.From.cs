using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public static Builder From([AllowNull] params T[] source)
            =>
            source is null ? default : new(InnerArrayHelper.Clone(source), default);

        public static Builder From(FlatArray<T> source)
            =>
            source.ToBuilder();

        public static Builder From(FlatArray<T>? source)
            =>
            source is null ? default : source.Value.ToBuilder();

        public static Builder From([AllowNull] List<T> source)
            =>
            source is null ? default : InnerFromList(source);

        public static Builder From(ImmutableArray<T> source)
            =>
            InnerFromImmutableArray(source);

        public static Builder From(ImmutableArray<T>? source)
            =>
            source is null ? default : InnerFromImmutableArray(source.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Builder InnerFromList(List<T> source)
        {
            var count = source.Count;
            if (count == default)
            {
                return default;
            }

            var array = new T[count];
            source.CopyTo(array, 0);

            return new(array, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Builder InnerFromImmutableArray(ImmutableArray<T> source)
        {
            if (source.IsDefaultOrEmpty)
            {
                return default;
            }

            var array = new T[source.Length];
            source.CopyTo(array, 0);

            return new(array, default);
        }
    }
}
