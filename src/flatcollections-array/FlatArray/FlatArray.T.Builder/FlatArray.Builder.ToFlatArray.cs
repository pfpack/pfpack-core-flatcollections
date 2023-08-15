namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Add the tests and make public
        internal FlatArray<T> ToFlatArray()
            =>
            length == default ? default : new(InnerArrayHelper.Copy(items, length), default);
    }
}
