namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<TOther>? TryCastArray<TOther>() where TOther : class?
    {
        // Safe 'as' cast

        if (InnerItems() is not TOther[] otherItems)
        {
            return null;
        }

        var otherItemsNormalized = items is null ? null : otherItems;

        return new(length, otherItemsNormalized, default);
    }
}
