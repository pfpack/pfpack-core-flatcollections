using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

using TestTheoryData = TheoryData<string?, string[]?, StringSplitOptions, string[]?, int>;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [MemberData(nameof(SplitToFlatArray_WithStringSeparators_ExpectCorrectState_Cases))]
    public void SplitToFlatArray_WithStringSeparators_ExpectCorrectState(
        string? source, string[]? separators, StringSplitOptions options, string[]? expectedItems, int expectedLength)
    {
        var actual = source.SplitToFlatArray(separators, options);
        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    public static TestTheoryData SplitToFlatArray_WithStringSeparators_ExpectCorrectState_Cases
        =>
        [
            new(null, [","], StringSplitOptions.None, null, default),
            new(string.Empty, [","], StringSplitOptions.None, [string.Empty], 1),
            new(string.Empty, [","], StringSplitOptions.RemoveEmptyEntries, null, default),
            new("a,b;c", [",", ";"], StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a,,c", [",", ";"], StringSplitOptions.None, ["a", "", "c"], 3),
            new("a,,c", [","], StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new(",;a;;b,", [",", ";"], StringSplitOptions.None, ["", "", "a", "", "b", ""], 6),
            new(",;a;;b,", [",", ";"], StringSplitOptions.RemoveEmptyEntries, ["a", "b"], 2),
            new("a||b<>c", ["||", "<>"], StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a||||c", ["||"], StringSplitOptions.None, ["a", "", "c"], 3),
            new("a||||c", ["||"], StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new(" a :: b -- c ", ["::", "--"], StringSplitOptions.None, [" a ", " b ", " c "], 3),
            new(" a :: b -- c ", ["::", "--"], StringSplitOptions.TrimEntries, ["a", "b", "c"], 3),
            new(" a ::  -- c ", ["::", "--"], StringSplitOptions.TrimEntries, ["a", "", "c"], 3),
            new(" a ::  -- c ", ["::", "--"], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new("a b\tc", null, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("   ", null, StringSplitOptions.None, ["", "", "", ""], 4),
            new("   ", null, StringSplitOptions.RemoveEmptyEntries, null, default),
            new("one", ["x", "y"], StringSplitOptions.None, ["one"], 1),
            new("xone", ["x"], StringSplitOptions.None, ["", "one"], 2),
            new("onex", ["x"], StringSplitOptions.RemoveEmptyEntries, ["one"], 1),
            new("α||β<>γ", ["||", "<>"], StringSplitOptions.None, ["α", "β", "γ"], 3),
            new("a b c", [], StringSplitOptions.None, ["a", "b", "c"], 3)
        ];
}
