namespace System;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        // TODO: Make public when dynamic builder is implemented
        internal void Clear()
        {
            if (InnerIsEmpty)
            {
                return;
            }

            this = default;
        }
    }
}
