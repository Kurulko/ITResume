using ITResume.Server.Database;
using ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Octokit;
using System;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManagers.SkillUserITResumeManagers;

public abstract class SkillUserITResumeManager<T> : UserITResumeManager<T>, ISkillService<T> where T : SkillUserITResumeDbModel
{
    protected readonly string tableProgrammingLanguagesModelsName, tableTechnologiesModelsName, modelIdName;
    protected SkillUserITResumeManager(string tableProgrammingLanguagesModelsName, string tableTechnologiesModelsName, string modelIdName,
        ITResumeContext db, IUserService userService) : base(db, userService)
    {
        this.tableProgrammingLanguagesModelsName = tableProgrammingLanguagesModelsName;
        this.tableTechnologiesModelsName = tableTechnologiesModelsName;
        this.modelIdName = modelIdName;
    }

    const string programmingLanguagesIdName = "ProgrammingLanguagesId";
    const string technologiesIdName = "TechnologiesId";

    (IEnumerable<long>? languagesId, IEnumerable<long>? technologiesId) GetLanguagesAndTechnologiesId(T model)
    {
        var languagesId = model.ProgrammingLanguages?.Select(l => l.Id);
        model.ProgrammingLanguages = null;

        var technologiesId = model.Technologies?.Select(l => l.Id);
        model.Technologies = null;

        return (languagesId, technologiesId);
    }

    public override async Task<T> AddModelAsync(T model)
    {
        var (languagesId, technologiesId) = GetLanguagesAndTechnologiesId(model);

        await base.AddModelAsync(model);

        long modelId = model.Id;

        if (languagesId is not null)
            await AddProgrammingLanguagesToModel(modelId, languagesId);

        if (technologiesId is not null)
            await AddTechnologiesToModel(modelId, technologiesId);

        return model;
    }

    public override async Task UpdateModelAsync(T model)
    {
        var (languagesId, technologiesId) = GetLanguagesAndTechnologiesId(model);

        await base.UpdateModelAsync(model);
        
        long modelId = model.Id;

        if (languagesId is not null)
            await UpdateProgrammingLanguagesInModel(modelId, languagesId);

        if (technologiesId is not null)
            await UpdateTechnologiesInModel(modelId, technologiesId);
    }

    public async Task AddProgrammingLanguagesToModel(long modelId, IEnumerable<long> programmingLanguageIds)
    {
        foreach (long programmingLanguageId in programmingLanguageIds)
            await AddProgrammingLanguageToModel(modelId, programmingLanguageId);
    }

    public async Task AddProgrammingLanguageToModel(long modelId, long programmingLanguageId)
        => await AddForeignModelToModel(tableProgrammingLanguagesModelsName, modelIdName, programmingLanguagesIdName, modelId, programmingLanguageId);

    public async Task AddTechnologiesToModel(long modelId, IEnumerable<long> technologyIds)
    {
        foreach (long technologyId in technologyIds)
            await AddTechnologyToModel(modelId, technologyId);
    }

    public async Task AddTechnologyToModel(long modelId, long technologyId)
        => await AddForeignModelToModel(tableTechnologiesModelsName, modelIdName, technologiesIdName, modelId, technologyId);

    public Task RemoveAllProgrammingLanguagesFromModel(long modelId)
        => RemoveAllForeignModelsFromModel(tableProgrammingLanguagesModelsName, modelIdName, modelId);

    public Task RemoveAllTechnologiesFromModel(long modelId)
        => RemoveAllForeignModelsFromModel(tableTechnologiesModelsName, modelIdName, modelId);

    public Task RemoveProgrammingLanguageFromModel(long modelId, long programmingLanguageId)
        => RemoveForeignModelFromModel(tableProgrammingLanguagesModelsName, modelIdName, programmingLanguagesIdName, modelId, programmingLanguageId);

    public async Task RemoveProgrammingLanguagesFromModel(long modelId, IEnumerable<long> programmingLanguageIds)
    {
        foreach (long programmingLanguageId in programmingLanguageIds)
            await RemoveProgrammingLanguageFromModel(modelId, programmingLanguageId);
    }

    public async Task RemoveTechnologiesFromModel(long modelId, IEnumerable<long> technologyIds)
    {
        foreach (long technologyId in technologyIds)
            await RemoveTechnologyFromModel(modelId, technologyId);
    }

    public Task RemoveTechnologyFromModel(long modelId, long technologyId)
        => RemoveForeignModelFromModel(tableTechnologiesModelsName, modelIdName, technologiesIdName, modelId, technologyId);

    public Task UpdateProgrammingLanguageInModel(long modelId, long programmingLanguageId)
        => UpdateForeignModelInModel(tableProgrammingLanguagesModelsName, modelIdName, programmingLanguagesIdName, modelId, programmingLanguageId);

    public Task UpdateProgrammingLanguagesInModel(long modelId, IEnumerable<long> programmingLanguageIds)
        => UpdateForeignModelsInModel(tableProgrammingLanguagesModelsName, modelIdName, programmingLanguagesIdName, modelId, programmingLanguageIds.Select(pl => (object)pl));

    public Task UpdateTechnologiesInModel(long modelId, IEnumerable<long> technologyIds)
        => UpdateForeignModelsInModel(tableTechnologiesModelsName, modelIdName, technologiesIdName, modelId, technologyIds.Select(pl => (object)pl));

    public Task UpdateTechnologyInModel(long modelId, long technologyId)
        => UpdateForeignModelInModel(tableTechnologiesModelsName, modelIdName, technologiesIdName, modelId, technologyId);
}
