using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;

namespace ITResume.Client.Managers.ITResumeManagers.UserITResumeManagers.SkillITResumeDbModelManager;

public abstract class SkillITResumeDbModelManager<T> : ITResumeDbModelManager<T>, ISkillService<T> where T : SkillUserITResumeDbModel, new()
{
    protected SkillITResumeDbModelManager(HttpClient httpClient, string url) : base(httpClient, url) { }

    public async Task AddProgrammingLanguagesToModel(long modelId, IEnumerable<long> programmingLanguageIds)
        => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/programming-languages",
            new IdAndIds<long, long>() { Id = modelId, Ids = programmingLanguageIds }));

    public async Task AddProgrammingLanguageToModel(long modelId, long programmingLanguageId)
    => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/programming-language",
            new IdAndId<long, long>() { Id1 = modelId, Id2 = programmingLanguageId }));

    public async Task UpdateProgrammingLanguagesInModel(long modelId, IEnumerable<long> programmingLanguageIds)
        => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/programming-languages",
            new IdAndIds<long, long>() { Id = modelId, Ids = programmingLanguageIds }));

    public async Task UpdateProgrammingLanguageInModel(long modelId, long programmingLanguageId)
    => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/programming-language",
            new IdAndId<long, long>() { Id1 = modelId, Id2 = programmingLanguageId }));

    public async Task RemoveProgrammingLanguagesFromModel(long modelId, IEnumerable<long> programmingLanguageIds)
    {
        foreach (long programmingLanguageId in programmingLanguageIds)
            await RemoveProgrammingLanguageFromModel(modelId, programmingLanguageId);
    }

    public async Task RemoveProgrammingLanguageFromModel(long modelId, long programmingLanguageId)
        => await CheckResponseMessage(await httpClient.DeleteAsync($"{url}/programming-languages/{modelId}/{programmingLanguageId}"));

    public async Task RemoveAllProgrammingLanguagesFromModel(long modelId)
        => await CheckResponseMessage(await httpClient.DeleteAsync($"{url}/programming-languages/{modelId}"));



    public async Task AddTechnologiesToModel(long modelId, IEnumerable<long> technologyIds)
        => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/technologies",
            new IdAndIds<long, long>() { Id = modelId, Ids = technologyIds }));

    public async Task AddTechnologyToModel(long modelId, long technologyId)
        => await CheckResponseMessage(await httpClient.PostAsJsonAsync($"{url}/technology",
            new IdAndId<long, long>() { Id1 = modelId, Id2 = technologyId }));

    public async Task UpdateTechnologiesInModel(long modelId, IEnumerable<long> technologyIds)
    => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/technologies",
        new IdAndIds<long, long>() { Id = modelId, Ids = technologyIds }));

    public async Task UpdateTechnologyInModel(long modelId, long technologyId)
    => await CheckResponseMessage(await httpClient.PutAsJsonAsync($"{url}/technology",
            new IdAndId<long, long>() { Id1 = modelId, Id2 = technologyId }));

    public async Task RemoveTechnologiesFromModel(long modelId, IEnumerable<long> technologyIds)
    {
        foreach (long technologyId in technologyIds)
            await RemoveTechnologyFromModel(modelId, technologyId);
    }

    public async Task RemoveTechnologyFromModel(long modelId, long technologyId)
        => await CheckResponseMessage(await httpClient.DeleteAsync($"{url}/technologies/{modelId}/{technologyId}"));

    public async Task RemoveAllTechnologiesFromModel(long modelId)
        => await CheckResponseMessage(await httpClient.DeleteAsync($"{url}/technologies/{modelId}"));

}
