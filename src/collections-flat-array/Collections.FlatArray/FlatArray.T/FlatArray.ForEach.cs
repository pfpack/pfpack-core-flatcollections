namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public void ForEach(Action<T> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));

        if (InnerIsEmpty)
        {
            return;
        }

        for (int i = 0; i < items.Length; i++)
        {
            action.Invoke(items[i]);
        }
    }

    public void ForEach(Action<int, T> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));

        if (InnerIsEmpty)
        {
            return;
        }

        for (int i = 0; i < items.Length; i++)
        {
            action.Invoke(i, items[i]);
        }
    }
}
