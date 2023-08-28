using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public static FlatArray<T> From([AllowNull] IEnumerable<T> source)
        =>
        source switch
        {
            null => default,

            T[] items
            =>
            items.Length == default ? default : new(InnerArrayHelper.Copy(items), default),

            List<T> items
            =>
            InnerFactoryHelper.FromICollectionTrusted(items),

            FlatList items
            =>
            InnerFactoryHelper.FromICollectionTrusted(items),

            ImmutableArray<T> items
            =>
            new(items),

            ICollection<T> items
            =>
            InnerFactoryHelper.FromICollection(items),

            IReadOnlyList<T> items
            =>
            InnerFactoryHelper.FromIReadOnlyList(items),

            IReadOnlyCollection<T> items
            =>
            InnerFactoryHelper.FromIEnumerable(items, items.Count),

            _ =>
            InnerFactoryHelper.FromIEnumerable(source)
        };
}
