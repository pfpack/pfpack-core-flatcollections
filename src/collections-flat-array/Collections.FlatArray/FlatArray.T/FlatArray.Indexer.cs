namespace System.Collections.Generic;

partial class FlatArray<T>
{
    public T this[int index]
    {
        get
        {
            if ((index >= 0 && index < items.Length) is false)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), index, "The index must be greater than or equal to zero and less than the array length.");
            }

            return items[index];
        }
    }
}
