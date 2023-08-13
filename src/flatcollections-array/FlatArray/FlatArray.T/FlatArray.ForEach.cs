using System.Runtime.CompilerServices;

namespace System;

partial struct FlatArray<T>
{
    public void ForEach(Action<T> action)
        =>
        InternalForEach(action ?? throw new ArgumentNullException(nameof(action)));

    public void ForEach(Action<int, T> action)
        =>
        InternalForEach(action ?? throw new ArgumentNullException(nameof(action)));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void InternalForEach(Action<T> action)
    {
        for (int i = 0; i < length; i++) { action.Invoke(items![i]); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void InternalForEach(Action<int, T> action)
    {
        for (int i = 0; i < length; i++) { action.Invoke(i, items![i]); }
    }
}
