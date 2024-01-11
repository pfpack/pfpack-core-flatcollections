using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        public static Builder From([AllowNull] params T[] source)
            =>
            new(source);

        public static Builder From(FlatArray<T> source)
            =>
            InnerFromFlatArray(source);

        public static Builder From(FlatArray<T>? source)
            =>
            source is null ? new() : InnerFromFlatArray(source.Value);

        public static Builder From([AllowNull] List<T> source)
            =>
            source is null ? new() : InnerFromList(source);

        public static Builder From(ImmutableArray<T> source)
            =>
            InnerFromImmutableArray(source);

        public static Builder From(ImmutableArray<T>? source)
            =>
            source is null ? new() : InnerFromImmutableArray(source.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Builder InnerFromFlatArray(FlatArray<T> source)
            =>
            source.length == default ? new() : new(InnerArrayHelper.Copy(source.items!, source.length), default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Builder InnerFromList(List<T> source)
        {
            var count = source.Count;

            if (count == default)
            {
                return new();
            }

            var array = new T[count];
            source.CopyTo(array);

            return new(array, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Builder InnerFromImmutableArray(ImmutableArray<T> source)
        {
            if (source.IsDefaultOrEmpty)
            {
                return new();
            }

            var array = new T[source.Length];
            source.CopyTo(array);

            return new(array, default);
        }
    }
}
