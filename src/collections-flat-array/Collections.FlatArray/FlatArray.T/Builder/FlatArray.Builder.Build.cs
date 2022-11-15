namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public FlatArray<T> Build()
        {
            if (isBuilt)
            {
                throw new InvalidOperationException("The flat array is already built.");
            }

            isBuilt = true;

            return InnerIsNotEmpty ? new(items, default) : default;
        }
    }
}
