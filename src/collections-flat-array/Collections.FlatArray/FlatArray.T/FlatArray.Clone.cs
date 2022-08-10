namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public FlatArray<T> Clone()
        =>
        new(InnerCloneItemsDefault(), default);

    object ICloneable.Clone()
        =>
        Clone();

    public FlatArray<T> Clone(FlatArrayCloneMode mode)
        =>
        new(InnerCloneItems(mode, nameof(mode)), default);

    private T[] InnerCloneItemsDefault()
        =>
        items.Length > 0 ? InnerArrayHelper.Clone(items) : items;

    private T[] InnerCloneItems(FlatArrayCloneMode mode, string paramName)
        =>
        mode switch
        {
            FlatArrayCloneMode.Default
            =>
            InnerCloneItemsDefault(),

            FlatArrayCloneMode.Shallow
            =>
            items,

            FlatArrayCloneMode.Deep
            =>
            InnerArrayHelper.Clone(items),

            _ =>
            throw InnerExceptionFactory.UnexpectedCloneMode(paramName, mode)
        };
}
