namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public sealed class EqualityComparer : IEqualityComparer<FlatArray<T>>
    {
        private readonly IEqualityComparer<T> comparer;

        private EqualityComparer(IEqualityComparer<T> comparer)
            =>
            this.comparer = comparer;

        public static EqualityComparer Create(IEqualityComparer<T>? comparer)
            =>
            new(comparer ?? EqualityComparer<T>.Default);

        public static EqualityComparer Create()
            =>
            new(EqualityComparer<T>.Default);

        public static EqualityComparer Default
            =>
            InnerDefault.Value;

        public bool Equals(FlatArray<T> x, FlatArray<T> y)
        {
            if (x.length != y.length)
            {
                return false;
            }

            if (x.InnerIsEmpty)
            {
                return true;
            }

            if (ReferenceEquals(x.items, y.items))
            {
                return true;
            }

            for (int i = 0; i < x.length; i++)
            {
                if (comparer.Equals(x.items[i], y.items![i]))
                {
                    continue;
                }
                return false;
            }

            return true;
        }

        public int GetHashCode(FlatArray<T> obj)
        {
            HashCode builder = new();

            if (obj.InnerIsEmpty)
            {
                return builder.ToHashCode();
            }

            for (int i = 0; i < obj.length; i++)
            {
                var item = obj.items[i];
                builder.Add(item is null ? default : comparer.GetHashCode(item));
            }

            return builder.ToHashCode();
        }

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
