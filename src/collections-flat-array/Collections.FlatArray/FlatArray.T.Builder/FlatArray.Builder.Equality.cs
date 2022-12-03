using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // The Builder Equality implements a reference-based comparison

        public bool Equals(Builder other)
            =>
            length == other.length &&
            ReferenceEquals(items, other.items);

        public static bool Equals(Builder left, Builder right)
            =>
            left.Equals(right);

        public static bool operator ==(Builder left, Builder right)
            =>
            left.Equals(right);

        public static bool operator !=(Builder left, Builder right)
            =>
            left.Equals(right) is not true;

        // This method is not supported as ref structs cannot be boxed
        [Obsolete(EqualsNotSupportedMessage, error: true)]
        [DoesNotReturn]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override bool Equals([NotNullWhen(true)] object? obj)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
            =>
            throw new NotSupportedException(EqualsNotSupportedMessage);

        // This method is not supported as ref structs cannot be boxed
        [Obsolete(GetHashCodeNotSupportedMessage, error: true)]
        [DoesNotReturn]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override int GetHashCode()
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
            =>
            throw new NotSupportedException(GetHashCodeNotSupportedMessage);

        private const string EqualsNotSupportedMessage
            =
            "Equals(Object) on FlatArray<T>.Builder is not supported. Use the Equals(Builder) instead.";

        private const string GetHashCodeNotSupportedMessage
            =
            "GetHashCode() on FlatArray<T>.Builder is not supported.";
    }
}
