using static System.FormattableString;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    private static class InnerExceptionMessages
    {
        internal static string UnexpectedCloneMode(FlatArrayCloneMode actualValue)
            =>
            Invariant(
                $"An unexpected value of the clone mode. Actual value was {actualValue}.");

        internal static string IndexOutOfRange(int actualValue)
            =>
            Invariant(
                $"Index must be greater than or equal to zero and less than the array length. Actual value was {actualValue}.");

        internal const string EnumerationEitherNotStartedOrFinished
            =
            "Enumeration has either not started or has already finished.";
    }
}
