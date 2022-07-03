using static System.FormattableString;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public FlatArray<T> Clone()
        =>
        InnerClone(default);

    object ICloneable.Clone()
        =>
        InnerClone(default);

    public FlatArray<T> Clone(FlatArrayCloneMode mode)
        =>
        InnerClone(mode);

    private FlatArray<T> InnerClone(FlatArrayCloneMode mode)
        =>
        new(InnerCloneBuildItems(mode), default);

    private T[] InnerCloneBuildItems(FlatArrayCloneMode mode)
        =>
        mode switch
        {
            FlatArrayCloneMode.Default
            =>
            items.Length > 0 ? InnerCloneArray(items) : items,

            FlatArrayCloneMode.Shallow
            =>
            items,

            FlatArrayCloneMode.Deep
            =>
            InnerCloneArray(items),

            _ => throw new ArgumentOutOfRangeException(
                nameof(mode), Invariant($"{mode}"), InnerExceptionMessages.UnexpectedCloneModeValue)
        };
}
