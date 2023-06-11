namespace ITResume.Client.Extensions;

public static class IEnumerableExtensions
{
    public static int CountOrDefault<T>(this IEnumerable<T>? elements)
        => elements?.Count() ?? default;

    public static bool IsCountOverZero<T>(this IEnumerable<T>? elements)
        => elements.CountOrDefault() > 0;
}