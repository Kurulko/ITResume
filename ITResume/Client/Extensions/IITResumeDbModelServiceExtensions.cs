using ITResume.Shared.Models.Database;
using ITResume.Shared.Services.ITResumeServices;

namespace ITResume.Client.Extensions;

public static class IITResumeDbModelServiceExtensions
{
    public static async Task UpdateModelsAsync<T>(this IITResumeDbModelService<T> service, IEnumerable<T> models) where T : ITResumeDbModel
    {
        foreach (T model in models)
            await service.UpdateModelAsync(model);
    }

}
