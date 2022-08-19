namespace System.Collections.Generic;

partial class FlatArray<T>
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

        public bool Equals(FlatArray<T>? x, FlatArray<T>? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            if (ReferenceEquals(x.items, y.items))
            {
                return true;
            }

            if (x.items.Length != y.items.Length)
            {
                return false;
            }

            for (int i = 0; i < x.items.Length; i++)
            {
                if (comparer.Equals(x.items[i], y.items[i]))
                {
                    continue;
                }
                return false;
            }

            return true;
        }

        public int GetHashCode(FlatArray<T> obj)
        {
            // Return zero instead of throwing ArgumentNullException
            if (obj is null)
            {
                return default;
            }

            HashCode builder = new();

            for (int i = 0; i < obj.items.Length; i++)
            {
                var item = obj.items[i];
                builder.Add(item is not null ? comparer.GetHashCode(item) : default);
            }

            return builder.ToHashCode();
        }

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
