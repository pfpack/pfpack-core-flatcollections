namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<TOther> CastArray<TOther>()
    {
        // Unsafe array cast: InvalidCastException is expected

        var otherItems = (TOther[])(object)InnerItems();

        var otherItemsNormalized = items is null ? null : otherItems;

        return new(length, otherItemsNormalized, default);
    }
}
