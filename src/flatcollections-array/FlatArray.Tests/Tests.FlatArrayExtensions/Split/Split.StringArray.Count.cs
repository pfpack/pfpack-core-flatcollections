using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

using TestTheoryData = TheoryData<string?, string[]?, int, StringSplitOptions, string[]?, int>;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [MemberData(nameof(SplitToFlatArray_WithStringSeparatorsAndCount_ExpectCorrectState_Cases))]
    public void SplitToFlatArray_WithStringSeparatorsAndCount_ExpectCorrectState(
        string? source, string[]? separators, int count, StringSplitOptions options, string[]? expectedItems, int expectedLength)
    {
        var actual = source.SplitToFlatArray(separators, count, options);
        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    public static TestTheoryData SplitToFlatArray_WithStringSeparatorsAndCount_ExpectCorrectState_Cases
        =>
        [
            new(null, [","], 1, StringSplitOptions.None, null, default),
            new("a,b;c", [",", ";"], -5, StringSplitOptions.None, null, default),
            new("a,b;c", [",", ";"], -1, StringSplitOptions.RemoveEmptyEntries, null, default),
            new(string.Empty, [","], 1, StringSplitOptions.None, [string.Empty], 1),
            new(string.Empty, [","], 1, StringSplitOptions.RemoveEmptyEntries, null, default),
            new("a,b;c", [",", ";"], 1, StringSplitOptions.None, ["a,b;c"], 1),
            new("a,b;c", [",", ";"], 2, StringSplitOptions.None, ["a", "b;c"], 2),
            new("a,b;c", [",", ";"], 3, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a,b;c", [",", ";"], 10, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a,,c", [","], 2, StringSplitOptions.None, ["a", ",c"], 2),
            new("a,,c", [","], 3, StringSplitOptions.None, ["a", "", "c"], 3),
            new("a,,c", [","], 3, StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new(",;a;;b,", [",", ";"], 2, StringSplitOptions.None, ["", ";a;;b,"], 2),
            new(",;a;;b,", [",", ";"], 6, StringSplitOptions.None, ["", "", "a", "", "b", ""], 6),
            new(",;a;;b,", [",", ";"], 6, StringSplitOptions.RemoveEmptyEntries, ["a", "b"], 2),
            new("a||b<>c", ["||", "<>"], 2, StringSplitOptions.None, ["a", "b<>c"], 2),
            new("a||b<>c", ["||", "<>"], 3, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a||||c", ["||"], 3, StringSplitOptions.None, ["a", "", "c"], 3),
            new("a||||c", ["||"], 3, StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new(" a :: b -- c ", ["::", "--"], 3, StringSplitOptions.TrimEntries, ["a", "b", "c"], 3),
            new(" a ::  -- c ", ["::", "--"], 3, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new("a b c", null, 2, StringSplitOptions.None, ["a", "b c"], 2),
            new("a b c", null, 3, StringSplitOptions.RemoveEmptyEntries, ["a", "b", "c"], 3),
            new("   ", null, 1, StringSplitOptions.None, ["   "], 1),
            new("   ", null, 4, StringSplitOptions.RemoveEmptyEntries, null, default),
            new("a,b", [","], 0, StringSplitOptions.None, null, default),
            new("a b c", [], 2, StringSplitOptions.RemoveEmptyEntries, ["a", "b c"], 2)
        ];
}
