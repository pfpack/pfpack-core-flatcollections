namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public FlatArray<T> Clone()
        =>
        InnerIsNotEmpty ? new(InnerArrayHelper.Clone(items), default) : default;
}
