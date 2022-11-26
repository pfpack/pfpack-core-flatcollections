using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        [Obsolete(BuildNotSupportedMessage, error: true)]
        [DoesNotReturn]
        public FlatArray<T> Build()
            =>
            throw new NotSupportedException(BuildNotSupportedMessage);

        private const string BuildNotSupportedMessage
            =
            "Build() on FlatArray<T>.Builder is not supported. Use the MoveToArray() instead.";
    }
}
