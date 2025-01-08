using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public static void ConstructFromCollectionExpression_SourceIsEmpty_ExpectDefault()
    {
        FlatArray<string?>.Builder actual = [];
        actual.VerifyInnerState([], default);
    }

    [Fact]
    public static void ConstructFromCollectionExpression_SourceIsNotEmpty_ExpectInnerStateIsSourceCollection()
    {
        FlatArray<string?>.Builder actual = [ SomeString, null, EmptyString, WhiteSpaceString, AnotherString ];
        string?[] expectedItems = [ SomeString, null, EmptyString, WhiteSpaceString, AnotherString ];

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}
