using static System.FormattableString;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public override string ToString()
        =>
        Invariant($"FlatArray<{typeof(T).Name}>[{Length}]");
}
