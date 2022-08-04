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
        new(InnerCloneItems(mode), default);

    private T[] InnerCloneItems(FlatArrayCloneMode mode)
        =>
        mode switch
        {
            FlatArrayCloneMode.Default
            =>
            items.Length > 0 ? InnerArrayHelper.Clone(items) : items,

            FlatArrayCloneMode.Shallow
            =>
            items,

            FlatArrayCloneMode.Deep
            =>
            InnerArrayHelper.Clone(items),

            _ =>
            throw InnerExceptionFactory.UnexpectedCloneMode(nameof(mode), mode)
        };
}
