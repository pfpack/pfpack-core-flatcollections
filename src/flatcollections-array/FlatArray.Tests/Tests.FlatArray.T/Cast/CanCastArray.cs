using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    // Value types

    [Theory]
    [MemberData(nameof(CanCastArray_ValueType_TypeTheSame_ExpectTrue_CaseSource))]
    public void CanCastArray_ValueType_TypeTheSame_ExpectTrue(FlatArray<byte> source)
    {
        var actual = source.CanCastArray<byte>();
        Assert.True(actual);
    }

    public static TheoryData<FlatArray<byte>> CanCastArray_ValueType_TypeTheSame_ExpectTrue_CaseSource => new()
    {
        {
            Array.Empty<byte>().InitializeFlatArray()
        },
        {
            new byte[] { 1 }.InitializeFlatArray()
        },
        {
            new byte[] { 1, 2 }.InitializeFlatArray()
        }
    };

    [Theory]
    [MemberData(nameof(CanCastArray_ValueType_TypeCompatible_ExpectTrue_CaseSource))]
    public void CanCastArray_ValueType_TypeCompatible_ExpectTrue(FlatArray<byte> source)
    {
        var actual = source.CanCastArray<sbyte>();
        Assert.True(actual);
    }

    public static TheoryData<FlatArray<byte>> CanCastArray_ValueType_TypeCompatible_ExpectTrue_CaseSource => new()
    {
        {
            Array.Empty<byte>().InitializeFlatArray()
        },
        {
            new byte[] { 1 }.InitializeFlatArray()
        },
        {
            new byte[] { 1, 2 }.InitializeFlatArray()
        }
    };

    [Theory]
    [MemberData(nameof(CanCastArray_ValueType_TypeIncompatible_ExpectFalse_CaseSource))]
    public void CanCastArray_ValueType_TypeIncompatible_ExpectFalse(FlatArray<byte> source)
    {
        var actual = source.CanCastArray<ushort>();
        Assert.False(actual);
    }

    public static TheoryData<FlatArray<byte>> CanCastArray_ValueType_TypeIncompatible_ExpectFalse_CaseSource => new()
    {
        {
            Array.Empty<byte>().InitializeFlatArray()
        },
        {
            new byte[] { 1 }.InitializeFlatArray()
        },
        {
            new byte[] { 1, 2 }.InitializeFlatArray()
        }
    };

    // Reference types

    [Theory]
    [MemberData(nameof(CanCastArray_RefType_TypeTheSame_ExpectTrue_CaseSource))]
    public void CanCastArray_RefType_TypeTheSame_ExpectTrue(FlatArray<string> source)
    {
        var actual = source.CanCastArray<string>();
        Assert.True(actual);
    }

    public static TheoryData<FlatArray<string>> CanCastArray_RefType_TypeTheSame_ExpectTrue_CaseSource => new()
    {
        {
            Array.Empty<string>().InitializeFlatArray()
        },
        {
            new[] { "1" }.InitializeFlatArray()
        },
        {
            new[] { "1", "2" }.InitializeFlatArray()
        },
        {
            new[] { null!, "1", "2" }.InitializeFlatArray()
        }
    };

    [Theory]
    [MemberData(nameof(CanCastArray_RefType_TypeCompatible_ExpectTrue_CaseSource))]
    public void CanCastArray_RefType_TypeCompatible_ExpectTrue(FlatArray<string> source)
    {
        var actual = source.CanCastArray<object>();
        Assert.True(actual);
    }

    public static TheoryData<FlatArray<string>> CanCastArray_RefType_TypeCompatible_ExpectTrue_CaseSource => new()
    {
        {
            Array.Empty<string>().InitializeFlatArray()
        },
        {
            new[] { "1" }.InitializeFlatArray()
        },
        {
            new[] { "1", "2" }.InitializeFlatArray()
        },
        {
            new[] { null!, "1", "2" }.InitializeFlatArray()
        }
    };

    [Theory]
    [MemberData(nameof(CanCastArray_RefType_TypeIncompatible_ExpectFalse_CaseSource))]
    public void CanCastArray_RefType_TypeIncompatible_ExpectFalse(FlatArray<object> source)
    {
        var actual = source.CanCastArray<string>();
        Assert.False(actual);
    }

    public static TheoryData<FlatArray<object>> CanCastArray_RefType_TypeIncompatible_ExpectFalse_CaseSource => new()
    {
        {
            Array.Empty<object>().InitializeFlatArray()
        },
        {
            new[] { new object() }.InitializeFlatArray()
        },
        {
            new[] { new object(), new object() }.InitializeFlatArray()
        },
        {
            new[] { null!, new object(), new object() }.InitializeFlatArray()
        }
    };
}
