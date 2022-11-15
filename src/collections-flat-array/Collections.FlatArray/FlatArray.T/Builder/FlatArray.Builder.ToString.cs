using static System.FormattableString;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public override string ToString()
            =>
            Invariant($"FlatArray<{typeof(T).Name}>.Builder[{Length}]");
    }
}
