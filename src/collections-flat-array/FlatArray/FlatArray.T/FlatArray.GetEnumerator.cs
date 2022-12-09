namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public Enumerator GetEnumerator()
        =>
        new(InnerAsSpan());
}
