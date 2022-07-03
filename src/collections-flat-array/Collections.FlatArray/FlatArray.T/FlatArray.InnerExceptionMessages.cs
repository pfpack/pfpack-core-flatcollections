namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static class InnerExceptionMessages
    {
        internal const string UnexpectedCloneModeValue =
            "An unexpected value of the clone mode.";

        internal const string IndexRangeRequirements =
            "Index must be greater than or equal to zero and less than the array length.";

        internal const string EnumerationEitherNotStartedOrFinished =
            "Enumeration has either not started or has already finished.";
    }
}
