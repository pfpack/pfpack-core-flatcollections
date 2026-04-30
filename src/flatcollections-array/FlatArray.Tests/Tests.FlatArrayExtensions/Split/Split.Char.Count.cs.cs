using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

using TestTheoryData = TheoryData<string?, char, int, StringSplitOptions, string[]?, int>;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [MemberData(nameof(SplitToFlatArray_WithCharSeparatorAndCount_ExpectCorrectState_Cases))]
    public void SplitToFlatArray_WithCharSeparatorAndCount_ExpectCorrectState(
        string? source, char separator, int count, StringSplitOptions options, string[]? expectedItems, int expectedLength)
    {
        var actual = source.SplitToFlatArray(separator, count, options);
        actual.VerifyInnerState(expectedItems, expectedLength);
    }

    public static TestTheoryData SplitToFlatArray_WithCharSeparatorAndCount_ExpectCorrectState_Cases
        =>
        [
            new(null, 'a', 1, StringSplitOptions.None, null, default),
            new("a,b,c", ',', -5, StringSplitOptions.None, null, default),
            new("a,b,c", ',', -1, StringSplitOptions.RemoveEmptyEntries, null, default),
            new(string.Empty, ',', 1, StringSplitOptions.None, [string.Empty], 1),
            new(string.Empty, ',', 1, StringSplitOptions.RemoveEmptyEntries, null, default),
            new("a", ',', 1, StringSplitOptions.None, ["a"], 1),
            new("abc", ',', 1, StringSplitOptions.None, ["abc"], 1),
            new("a,b,c", ',', 1, StringSplitOptions.None, ["a,b,c"], 1),
            new("a,b,c", ',', 2, StringSplitOptions.None, ["a", "b,c"], 2),
            new("a,b,c", ',', 3, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a,b,c", ',', 10, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a,,c", ',', 2, StringSplitOptions.None, ["a", ",c"], 2),
            new("a,,c", ',', 3, StringSplitOptions.None, ["a", "", "c"], 3),
            new("a,,c", ',', 3, StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new(",,,", ',', 1, StringSplitOptions.None, [",,,"], 1),
            new(",,,", ',', 2, StringSplitOptions.None, ["", ",,"], 2),
            new(",,,", ',', 4, StringSplitOptions.None, ["", "", "", ""], 4),
            new(",,,", ',', 4, StringSplitOptions.RemoveEmptyEntries, null, default),
            new(",a,b,", ',', 2, StringSplitOptions.None, ["", "a,b,"], 2),
            new(",a,b,", ',', 4, StringSplitOptions.None, ["", "a", "b", ""], 4),
            new(",a,b,", ',', 4, StringSplitOptions.RemoveEmptyEntries, ["a", "b"], 2),
            new(" a , b , c ", ',', 3, StringSplitOptions.None, [" a ", " b ", " c "], 3),
            new(" a , b , c ", ',', 3, StringSplitOptions.TrimEntries, ["a", "b", "c"], 3),
            new(" a , , c ", ',', 3, StringSplitOptions.TrimEntries, ["a", "", "c"], 3),
            new(" a , , c ", ',', 3, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new("a|b|c", '|', 2, StringSplitOptions.None, ["a", "b|c"], 2),
            new("a|b|c", '|', 3, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a|b||c", '|', 4, StringSplitOptions.None, ["a", "b", "", "c"], 4),
            new("a|b||c", '|', 4, StringSplitOptions.RemoveEmptyEntries, ["a", "b", "c"], 3),
            new("|a|b|", '|', 2, StringSplitOptions.None, ["", "a|b|"], 2),
            new("|a|b|", '|', 4, StringSplitOptions.None, ["", "a", "b", ""], 4),
            new("|a|b|", '|', 4, StringSplitOptions.RemoveEmptyEntries, ["a", "b"], 2),
            new("   ", ' ', 1, StringSplitOptions.None, ["   "], 1),
            new("   ", ' ', 2, StringSplitOptions.None, ["", "  "], 2),
            new("   ", ' ', 4, StringSplitOptions.None, ["", "", "", ""], 4),
            new("   ", ' ', 4, StringSplitOptions.RemoveEmptyEntries, null, default),
            new("   ", ' ', 4, StringSplitOptions.TrimEntries, ["", "", "", ""], 4),
            new("   ", ' ', 4, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries, null, default),
            new("a b c", ' ', 2, StringSplitOptions.None, ["a", "b c"], 2),
            new("a b c", ' ', 3, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a b  c", ' ', 4, StringSplitOptions.None, ["a", "b", "", "c"], 4),
            new("a b  c", ' ', 4, StringSplitOptions.RemoveEmptyEntries, ["a", "b", "c"], 3),
            new(" a b c ", ' ', 5, StringSplitOptions.TrimEntries, ["", "a", "b", "c", ""], 5),
            new(" a b c ", ' ', 5, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries, ["a", "b", "c"], 3),
            new("a\tb\tc", '\t', 3, StringSplitOptions.None, ["a", "b", "c"], 3),
            new("a\t\tc", '\t', 3, StringSplitOptions.None, ["a", "", "c"], 3),
            new("a\t\tc", '\t', 3, StringSplitOptions.RemoveEmptyEntries, ["a", "c"], 2),
            new("α,β,γ", ',', 3, StringSplitOptions.None, ["α", "β", "γ"], 3),
            new("α,,γ", ',', 3, StringSplitOptions.None, ["α", "", "γ"], 3),
            new("α,,γ", ',', 3, StringSplitOptions.RemoveEmptyEntries, ["α", "γ"], 2),
            new("one", 'x', 1, StringSplitOptions.None, ["one"], 1),
            new("one", 'x', 3, StringSplitOptions.None, ["one"], 1),
            new("one", 'x', 3, StringSplitOptions.RemoveEmptyEntries, ["one"], 1),
            new("xone", 'x', 2, StringSplitOptions.None, ["", "one"], 2),
            new("onex", 'x', 2, StringSplitOptions.None, ["one", ""], 2),
            new("xone", 'x', 2, StringSplitOptions.RemoveEmptyEntries, ["one"], 1),
            new("onex", 'x', 2, StringSplitOptions.RemoveEmptyEntries, ["one"], 1)
        ];
}
