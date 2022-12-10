using static System.FormattableString;

namespace System;

partial struct FlatArray<T>
{
    public override string ToString()
        =>
        Invariant($"FlatArray<{typeof(T).Name}>[{Length}]");
}
