﻿using static System.FormattableString;

namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        private static class InnerBuilderExceptionFactory
        {
            internal static ArgumentOutOfRangeException LengthOutOfRange(string paramName, int actualValue)
                =>
                new(paramName, Invariant($"Array length must be greater than or equal to zero. Actual value was {actualValue}."));

            internal static ArgumentOutOfRangeException CapacityOutOfRange_MustBeGreaterThanOrEqualToZero(string paramName, int actualValue)
                =>
                new(paramName, Invariant($"Capacity must be greater than or equal to zero. Actual value was {actualValue}."));

            internal static ArgumentOutOfRangeException CapacityOutOfRange_MustBeGreaterThanOrEqualToLength(int actualValue, int length)
                =>
                new(null, Invariant($"Capacity must be greater than or equal to the array length. Actual value was {actualValue}. Array length was {length}."));
        }
    }
}
