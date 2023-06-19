using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;

namespace ITResume.Client.Extensions;

public static class EnumerableExtensions
{
    public static int CountOrDefault<T>(this IEnumerable<T>? elements)
        => elements?.Count() ?? default;

    public static bool IsCountOverZero<T>(this IEnumerable<T>? elements)
        => elements.CountOrDefault() > 0;

    public static IEnumerable<string>? SelectName(this IEnumerable<UniqueNameModel>? elements)
        => elements?.Select(e => e.Name);

    public static IEnumerable<T>? WhereNameContainsInStrCollection<T>(this IEnumerable<T> allElements, IEnumerable<string>? someElementsStr)
        where T : UniqueNameModel
        => someElementsStr is not null ? allElements.Where(pl => someElementsStr.Contains(pl.Name)) : default;
}