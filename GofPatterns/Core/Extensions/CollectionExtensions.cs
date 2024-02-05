namespace GofPatterns.Core.Extensions;

internal static class CollectionExtensions
{
    internal static List<T> Build<T>(this List<T> list, T item, params T[] items)
    {
        list.Add(item);
        list.AddRange(items);
        return list;
    }
}