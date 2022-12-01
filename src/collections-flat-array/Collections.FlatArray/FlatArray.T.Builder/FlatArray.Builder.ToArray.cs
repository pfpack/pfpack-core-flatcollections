namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal FlatArray<T> ToArray()
            =>
            span.IsEmpty ? default : new(InnerArrayHelper.Copy(items!, span.Length), default);
    }
}
