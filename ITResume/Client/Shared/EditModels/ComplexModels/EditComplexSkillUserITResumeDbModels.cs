using ITResume.Client.Extensions;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.AspNetCore.Components;

namespace ITResume.Client.Shared.EditModels.ComplexModels;

public abstract class EditComplexSkillUserITResumeDbModels<TModel> : EditComplexITResumeDbModels<TModel>
     where TModel : SkillUserITResumeDbModel
{
    protected IEnumerable<ProgrammingLanguage>? allLanguages;
    protected IEnumerable<string>? allLanguagesStr;

    protected IEnumerable<Technology>? allTechnologies;
    protected IEnumerable<string>? allTechnologiesStr;

    [Inject]
    public IProgrammingLanguageService ProgrammingLanguageService { get; set; } = null!;

    [Inject]
    public ITechnologyService TechnologyService { get; set; } = null!;

    [Inject]
    public IUserService UserService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            allLanguages = await ProgrammingLanguageService.GetAllModelsAsync();
            allLanguagesStr = allLanguages.SelectName();

            allTechnologies = await TechnologyService.GetAllModelsAsync();
            allTechnologiesStr = allTechnologies.SelectName();

            await base.OnInitializedAsync();
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }
}
