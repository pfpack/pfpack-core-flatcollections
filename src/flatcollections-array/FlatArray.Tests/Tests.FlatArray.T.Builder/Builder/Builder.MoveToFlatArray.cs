using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayBuilderTest
{
    [Fact]
    public void MoveToFlatArray_SourceIsDefault_ExpectArrayStateIsDefault()
    {
        var source = new FlatArray<string>.Builder();
        var actual = source.MoveToFlatArray();

        actual.VerifyInnerState_Default();
    }

    [Fact]
    public void MoveToFlatArray_SourceIsDefault_ExpectBuilderStateIsDefault()
    {
        var source = new FlatArray<RefType>.Builder();
        _ = source.MoveToFlatArray();

        source.VerifyInnerState([], default);
    }

    [Theory]
    [MemberData(nameof(MoveToFlatArray_SourceIsNotDefault_ExpectInnerStateTheSameAsBuilderStateSource))]
    public void MoveToFlatArray_SourceIsNotDefault_ExpectInnerStateTheSameAsBuilderState(
        int length,
        int?[] sourceItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(length);
        var actual = source.MoveToFlatArray();
        actual.VerifyInnerState_TheSameAssert(sourceItems, length);
    }

    [Theory]
    [MemberData(nameof(MoveToFlatArray_SourceIsNotDefault_WithHugeCapacity_ExpectInnerStateCorrespondToBuilderStateSource))]
    public void MoveToFlatArray_SourceIsNotDefault_WithHugeCapacity_ExpectInnerStateCorrespondToBuilderState(
        int length,
        int?[] sourceItems,
        int?[] expectedItems)
    {
        var source = sourceItems.InitializeFlatArrayBuilder(length);
        var actual = source.MoveToFlatArray();
        actual.VerifyInnerState(expectedItems, length);
    }

    [Fact]
    public void MoveToFlatArray_SourceIsNotDefault_ExpectBuilderStateIsDefault()
    {
        var source = new[] { MinusFifteen, Zero, PlusFifteen, int.MaxValue, One }.InitializeFlatArrayBuilder();
        _ = source.MoveToFlatArray();

        source.VerifyInnerState([], default);
    }

    public static TheoryData<int, int?[]> MoveToFlatArray_SourceIsNotDefault_ExpectInnerStateTheSameAsBuilderStateSource
        =>
        new()
        {
            {
                1,
                [ 0 ]
            },
            {
                1,
                [ 0, null ]
            },
            {
                1,
                [ 0, null, null ]
            },
            {
                1,
                [ 0, null, null, null ]
            },
            {
                2,
                [ 0, 1 ]
            },
            {
                2,
                [ 0, 1, null ]
            },
            {
                2,
                [ 0, 1, null, null ]
            },
            {
                3,
                [ 0, 1, 2 ]
            },
            {
                3,
                [ 0, 1, 2, null ]
            },
            {
                3,
                [ 0, 1, 2, null, null ]
            },
            {
                4,
                [ 0, 1, 2, 3 ]
            },
            {
                4,
                [ 0, 1, 2, 3, null ]
            },
            {
                4,
                [ 0, 1, 2, 3, null, null ]
            },
            {
                4,
                [ 0, 1, 2, 3, null, null, null ]
            }
        };

    public static TheoryData<int, int?[], int?[]> MoveToFlatArray_SourceIsNotDefault_WithHugeCapacity_ExpectInnerStateCorrespondToBuilderStateSource
        =>
        new()
        {
            {
                1,
                [ 0, null, null, null, null ],
                [ 0 ]
            },
            {
                1,
                [ 0, null, null, null, null, null ],
                [ 0 ]
            },
            {
                2,
                [ 0, 1, null, null, null ],
                [ 0, 1 ]
            },
            {
                2,
                [ 0, 1, null, null, null, null ],
                [ 0, 1 ]
            },
            {
                3,
                [ 0, 1, 2, null, null, null ],
                [ 0, 1, 2 ]
            },
            {
                3,
                [ 0, 1, 2, null, null, null, null ],
                [ 0, 1, 2 ]
            },
            {
                4,
                [ 0, 1, 2, 3, null, null, null, null ],
                [ 0, 1, 2, 3 ]
            },
            {
                4,
                [ 0, 1, 2, 3, null, null, null, null, null ],
                [ 0, 1, 2, 3 ]
            }
        };
}
