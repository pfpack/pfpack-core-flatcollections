using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

partial class FlatArrayExtensions
{
    [Obsolete("This method is not intended for use. Read Length property instead.", error: true)]
    [DoesNotReturn]
    public static int Count<T>(this FlatArray<T> flatArray)
        =>
        throw new NotImplementedException();
}
