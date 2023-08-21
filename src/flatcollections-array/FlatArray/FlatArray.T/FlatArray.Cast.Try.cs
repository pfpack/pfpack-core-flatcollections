namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<TOther>? TryCast<TOther>() where TOther : class? // 'As' cast
    {
        if (InnerItems() is not TOther[] otherItems)
        {
            return null;
        }

        var otherItemsNormalized = items is null ? null : otherItems;

        return new(length, otherItemsNormalized, default);
    }
}
