using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void Slice_SliceOperatorSyntax_ExpectCorrectBehavior()
    {
        {
            var source = default(FlatArray<int>);
            var actual = source[..];
            actual.VerifyInnerState_Default();
        }

        {
            var source = new[] { MinusFifteen }.InitializeFlatArray();
            var actual = source[..0];
            actual.VerifyInnerState_Default();
        }

        {
            var source = new[] { MinusFifteen }.InitializeFlatArray();
            var actual = source[1..];
            actual.VerifyInnerState_Default();
        }

        {
            var source = new[] { MinusFifteen }.InitializeFlatArray();
            var actual = source[..];
            actual.VerifyInnerState([MinusFifteen], 1);
        }

        {
            var source = new[] { MinusFifteen, PlusFifteen }.InitializeFlatArray();
            var actual = source[1..2];
            actual.VerifyInnerState([PlusFifteen], 1);
        }

        {
            var source = new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen }.InitializeFlatArray();
            var actual = source[1..3];
            actual.VerifyInnerState([MinusOne, Zero], 2);
        }

        {
            var source = new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen }.InitializeFlatArray();
            var actual = source[..3];
            actual.VerifyInnerState([MinusFifteen, MinusOne, Zero], 3);
        }

        {
            var source = new[] { MinusFifteen, MinusOne, Zero, One, PlusFifteen }.InitializeFlatArray();
            var actual = source[1..];
            actual.VerifyInnerState([MinusOne, Zero, One, PlusFifteen], 4);
        }
    }
}
