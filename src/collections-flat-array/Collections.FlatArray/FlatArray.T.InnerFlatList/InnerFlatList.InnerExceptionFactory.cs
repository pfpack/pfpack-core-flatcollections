namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        private static class InnerExceptionFactory
        {
            internal static InvalidOperationException EnumerationEitherNotStartedOrFinished()
                =>
                new("Enumeration has either not started or has already finished.");

            internal static NotSupportedException NotSupportedOnReadOnlyCollection()
                =>
                new("The operation is not supported on read-only collection.");
        }
    }
}
