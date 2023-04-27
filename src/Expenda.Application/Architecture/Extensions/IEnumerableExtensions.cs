namespace Expenda.Application.Architecture.Extensions;

public static class IEnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection.Any();
}
