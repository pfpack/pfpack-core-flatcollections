namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        private static class InnerMaxLength
        {
            internal static readonly int Value = Array.MaxLength;
        }
    }
}
