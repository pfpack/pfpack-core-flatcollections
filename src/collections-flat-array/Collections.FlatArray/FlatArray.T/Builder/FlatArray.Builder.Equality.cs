using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public bool Equals(Builder other)
            =>
            length == other.Length &&
            ReferenceEquals(items, other.items) &&
            isBuilt == other.isBuilt;

        public static bool Equals(Builder left, Builder right)
            =>
            left.Equals(right);

        public static bool operator ==(Builder left, Builder right)
            =>
            left.Equals(right);

        public static bool operator !=(Builder left, Builder right)
            =>
            left.Equals(right) is not true;

        [Obsolete("Equals(object?) on FlatArray<T>.Builder will always throw an exception. Use the Equals(FlatArray<T>.Builder) instead.", error: true)]
        [DoesNotReturn]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override bool Equals([NotNullWhen(true)] object? obj)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
            =>
            throw new NotSupportedException();

        [Obsolete("GetHashCode() on FlatArray<T>.Builder will always throw an exception.", error: true)]
        [DoesNotReturn]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override int GetHashCode()
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
            =>
            throw new NotSupportedException();
    }
}
