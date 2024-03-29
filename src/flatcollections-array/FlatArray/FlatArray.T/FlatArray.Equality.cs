﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct FlatArray<T>
{
    public static bool Equals(FlatArray<T> left, FlatArray<T> right)
        =>
        left.Equals(right);

    public static bool operator ==(FlatArray<T> left, FlatArray<T> right)
        =>
        left.Equals(right);

    public static bool operator !=(FlatArray<T> left, FlatArray<T> right)
        =>
        left.Equals(right) is not true;

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is FlatArray<T> other &&
        Equals(other);

    public bool Equals(FlatArray<T> other)
    {
        if (length != other.length)
        {
            return false;
        }

        if (length == default)
        {
            return true;
        }

        if (ReferenceEquals(items, other.items))
        {
            return true;
        }

        for (int i = 0; i < length; i++)
        {
            if (InnerItemComparer.Value.Equals(items![i], other.items![i]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        HashCode builder = new();

        builder.Add(EqualityContractComparer.GetHashCode(EqualityContract));

        for (int i = 0; i < length; i++)
        {
            var item = items![i];
            builder.Add(item is null ? default : InnerItemComparer.Value.GetHashCode(item));
        }

        return builder.ToHashCode();
    }

    private static Type EqualityContract
        =>
        typeof(FlatArray<T>);

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static class InnerItemComparer
    {
        internal static readonly EqualityComparer<T> Value = EqualityComparer<T>.Default;
    }
}
