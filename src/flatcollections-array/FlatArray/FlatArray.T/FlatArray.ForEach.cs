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

    // TODO: When there is a huge number of breaking changes in a major update,
    // consider changing Action<int, T> to Action<T, int> to correspond the convention
    public void ForEach(Action<int, T> action)
    {
        _ = action ?? throw new ArgumentNullException(nameof(action));

        for (int i = 0; i < length; i++)
        {
            action.Invoke(i, items![i]);
        }
    }
}
