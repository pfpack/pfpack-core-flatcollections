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

    // TODO: Change Action<int, T> to Action<T, int> in FlatArray v2.0 to correspond the convention
    public void ForEach(Action<int, T> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));

        for (int i = 0; i < length; i++)
        {
            action.Invoke(i, items![i]);
        }
    }
}
