namespace PrimeFuncPack.Collections.FlatArray.Tests;

internal interface IItemAction<T>
{
    void Invoke(T item);

    void InvokeWithIndex(int index, T item);
}