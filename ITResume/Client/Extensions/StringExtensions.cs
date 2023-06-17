using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

namespace ITResume.Client.Extensions;

public static class StringExtensions
{
    public static string ToString(IEnumerable<ProgrammingLanguage>? values)
        => string.Join(',', values?.Select(t => t.Name) ?? Enumerable.Empty<string>());
    public static string ToString(IEnumerable<Technology>? values)
        => string.Join(',', values?.Select(t => t.Name) ?? Enumerable.Empty<string>());
}
