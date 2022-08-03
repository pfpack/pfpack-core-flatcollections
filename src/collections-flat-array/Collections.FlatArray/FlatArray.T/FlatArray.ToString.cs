using static System.FormattableString;

namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public override string ToString()
        =>
        Invariant($"FlatArray[{typeof(T)}]:{{ \"Length\": {Length} }}");
}
