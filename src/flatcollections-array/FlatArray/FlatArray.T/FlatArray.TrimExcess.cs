namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<T> TrimExcess()
        =>
        items is null || length == items.Length ? this : new(InnerArrayHelper.Copy(items, length), default);
}
