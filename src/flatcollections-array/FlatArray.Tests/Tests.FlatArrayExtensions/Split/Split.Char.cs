using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

using TestTheoryData = TheoryData<string?, char, StringSplitOptions, string[]?, int>;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [MemberData(nameof(SplitToFlatArray_WithCharSeparator_ExpectCorrectState_Cases))]
    public void SplitToFlatArray_WithCharSeparator_ExpectCorrectState(
        string? source, char separator, StringSplitOptions options, string[]? expectedItems, int expectedLength)
    {
        var actual = source.SplitToFlatArray(separator, options);
        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    public static TestTheoryData SplitToFlatArray_WithCharSeparator_ExpectCorrectState_Cases
        =>
        [
            new(null, 'a', StringSplitOptions.None, null, default),
            new(string.Empty, ',', StringSplitOptions.None, [string.Empty], 1),
            new(string.Empty, ',', StringSplitOptions.RemoveEmptyEntries, null, default),
            new("a", ',', StringSplitOptions.None, ["a"], 1),
            new("abc", ',', StringSplitOptions.None, ["abc"], 1),
            new("a,b,c", ',', StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a,,c", ',', StringSplitOptions.None, ["a", "", "c"], 3),
            new("a,,c", ',', StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new(",,,", ',', StringSplitOptions.None, ["", "", "", ""], 4),
            new(",,,", ',', StringSplitOptions.RemoveEmptyEntries, null, default),
            new(",a,b,", ',', StringSplitOptions.None, ["", "a", "b", ""], 4),
            new(",a,b,", ',', StringSplitOptions.RemoveEmptyEntries, ["a", "b"], 2),
            new(" a , b , c ", ',', StringSplitOptions.None, [" a ", " b ", " c "], 3),
            new(" a , b , c ", ',', StringSplitOptions.TrimEntries, ["a", "b", "c"], 3),
            new(" a , , c ", ',', StringSplitOptions.TrimEntries, ["a", "", "c"], 3),
            new(" a , , c ", ',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new("a|b|c", '|', StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a|b||c", '|', StringSplitOptions.None, ["a", "b", "", "c"], 4),
            new("a|b||c", '|', StringSplitOptions.RemoveEmptyEntries, ["a", "b", "c"], 3),
            new("|a|b|", '|', StringSplitOptions.None, ["", "a", "b", ""], 4),
            new("|a|b|", '|', StringSplitOptions.RemoveEmptyEntries, ["a", "b"], 2),
            new("   ", ' ', StringSplitOptions.None, ["", "", "", ""], 4),
            new("   ", ' ', StringSplitOptions.RemoveEmptyEntries, null, default),
            new("   ", ' ', StringSplitOptions.TrimEntries, ["", "", "", ""], 4),
            new("   ", ' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries, null, default),
            new("a b c", ' ', StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a b  c", ' ', StringSplitOptions.None, ["a", "b", "", "c"], 4),
            new("a b  c", ' ', StringSplitOptions.RemoveEmptyEntries, ["a", "b", "c"], 3),
            new(" a b c ", ' ', StringSplitOptions.TrimEntries, ["", "a", "b", "c", ""], 5),
            new("a\tb\tc", '\t', StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a\t\tc", '\t', StringSplitOptions.None, ["a", "", "c"], 3),
            new("a\t\tc", '\t', StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new("α,β,γ", ',', StringSplitOptions.None, ["α", "β", "γ"], 3),
            new("α,,γ", ',', StringSplitOptions.None, ["α", "", "γ"], 3),
            new("α,,γ", ',', StringSplitOptions.RemoveEmptyEntries, ["α", "γ"], 2),
            new("one", 'x', StringSplitOptions.None, ["one"], 1),
            new("one", 'x', StringSplitOptions.RemoveEmptyEntries, ["one"], 1),
            new("xone", 'x', StringSplitOptions.None, ["", "one"], 2),
            new("onex", 'x', StringSplitOptions.None, ["one", ""], 2),
            new("xone", 'x', StringSplitOptions.RemoveEmptyEntries, ["one"], 1),
            new("onex", 'x', StringSplitOptions.RemoveEmptyEntries, ["one"], 1)
        ];
}