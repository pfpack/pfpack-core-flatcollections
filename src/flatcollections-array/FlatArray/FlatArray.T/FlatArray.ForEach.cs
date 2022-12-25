namespace System;

partial struct FlatArray<T>
{
    public void ForEach(Action<T> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));

        for (int i = 0; i < length; i++)
        {
            action.Invoke(items![i]);
        }
    }

    public void ForEach(Action<int, T> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));

        for (int i = 0; i < length; i++)
        {
            action.Invoke(i, items![i]);
        }
    }
}
