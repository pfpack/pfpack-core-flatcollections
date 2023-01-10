namespace System;

partial struct FlatArray<T>
{
    partial class Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal FlatArray<T> ToFlatArray()
            =>
            length == default ? default : new(InnerArrayHelper.Copy(items, length), default);
    }
}
