namespace System.Collections.Generic;

partial class FlatArray<T>
{
    partial class InternalFactory
    {
        private static int InnerMaxLength => Array.MaxLength;
    }
}
