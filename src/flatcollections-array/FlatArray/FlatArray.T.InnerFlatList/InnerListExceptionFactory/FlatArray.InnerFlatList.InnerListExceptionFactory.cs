namespace System;

partial struct FlatArray<T>
{
    partial class InnerFlatList
    {
        private static class InnerListExceptionFactory
        {
            internal static NotSupportedException NotSupportedOnReadOnlyArray()
                =>
                new("The operation is not supported on read-only array.");
        }
    }
}
