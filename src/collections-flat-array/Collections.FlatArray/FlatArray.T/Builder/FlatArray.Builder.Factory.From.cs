using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public static Builder From([AllowNull] params T[] source)
            =>
            source is null ? default : new(InnerArrayHelper.Clone(source), default);
    }
}
