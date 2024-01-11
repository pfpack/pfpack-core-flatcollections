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
            default
        },
        {
            new FlatArray<byte>(1)
        },
        {
            new FlatArray<byte>(1, 2)
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
            default
        },
        {
            new FlatArray<byte>(1)
        },
        {
            new FlatArray<byte>(1, 2)
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
            default
        },
        {
            new FlatArray<byte>(1)
        },
        {
            new FlatArray<byte>(1, 2)
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
            default
        },
        {
            new FlatArray<string>("1")
        },
        {
            new FlatArray<string>("1", "2")
        },
        {
            new FlatArray<string>(null!, "1", "2")
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
            default
        },
        {
            new FlatArray<string>("1")
        },
        {
            new FlatArray<string>("1", "2")
        },
        {
            new FlatArray<string>(null!, "1", "2")
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
            default
        },
        {
            new FlatArray<object>(new object())
        },
        {
            new FlatArray<object>(new object(), new object())
        },
        {
            new FlatArray<object>(null!, new object(), new object())
        }
    };
}
