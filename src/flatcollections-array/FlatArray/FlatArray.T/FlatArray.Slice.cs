namespace System;

partial struct FlatArray<T>
{
    // TODO: Add the tests and make public
    internal FlatArray<T> Slice(int start, int length)
        =>
        From(this, start, length);
}
