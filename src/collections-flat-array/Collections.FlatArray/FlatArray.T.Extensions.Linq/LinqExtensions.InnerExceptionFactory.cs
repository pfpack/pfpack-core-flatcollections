namespace System.Linq;

partial class FlatArrayLinqExtensions
{
    public static class InnerExceptionFactory
    {
        internal static InvalidOperationException SourceEmpty()
            =>
            new("The source sequence is empty.");

        internal static InvalidOperationException SourceMoreThanOneElement()
            =>
            new("The source sequence contains more than one element.");
    }
}
