namespace System;

partial class FlatArray
{
    public static bool Equals<T>(FlatArray<T> left, FlatArray<T> right)
        =>
        left.Equals(right);
}
