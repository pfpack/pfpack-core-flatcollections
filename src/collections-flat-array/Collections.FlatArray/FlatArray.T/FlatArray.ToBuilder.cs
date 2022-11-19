namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public Builder ToBuilder()
        =>
        InnerIsNotEmpty ? new(InnerArrayHelper.Clone(items), default) : default;
}
