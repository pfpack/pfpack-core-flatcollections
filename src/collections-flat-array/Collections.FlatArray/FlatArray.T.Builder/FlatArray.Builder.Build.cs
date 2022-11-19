namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    partial struct Builder
    {
        public FlatArray<T> Build()
        {
            if (isBuilt)
            {
                throw InnerExceptionFactory.AlreadyBuilt();
            }

            isBuilt = true;

            return InnerIsNotEmpty ? new(items, default) : default;
        }
    }
}
