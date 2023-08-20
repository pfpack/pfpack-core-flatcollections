namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<TOther>? TryCast<TOther>() where TOther : class?
    {
        if (InnerItems() is not TOther[] otherItems)
        {
            return null;
        }

        var otherItemsNormalized = items is null ? null : otherItems;

        return new(length, otherItemsNormalized, default);
    }

    // TODO: Add the tests and make public
    [Obsolete("This method is not intended for use. Call TryCast instead.", error: true)]
    internal FlatArray<TOther>? As<TOther>() where TOther : class?
        =>
        throw new NotImplementedException();
}
