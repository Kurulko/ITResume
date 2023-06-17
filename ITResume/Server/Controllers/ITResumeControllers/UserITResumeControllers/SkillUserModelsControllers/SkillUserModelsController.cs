using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers.SkillUserModelsControllers;

public abstract class SkillUserModelsController<T> : UserITResumeDbModelsController<T> where T : SkillUserITResumeDbModel
{
    public SkillUserModelsController(IDbModelService<T, long> service, IUserService userService) : base(service, userService) { }

    protected ISkillService<T> skillService => (ISkillService<T>)service;

    [HttpPost("programming-languages")]
    public async Task<IActionResult> AddProgrammingLanguagesToModel(IdAndIds<long, long> modelAndProgrammingLanguageIds)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.AddProgrammingLanguagesToModel(modelAndProgrammingLanguageIds.Id, modelAndProgrammingLanguageIds.Ids));

    [HttpPost("programming-language")]
    public async Task<IActionResult> AddProgrammingLanguageToModel(IdAndId<long, long> modelAndProgrammingLanguageId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.AddProgrammingLanguageToModel(modelAndProgrammingLanguageId.Id1, modelAndProgrammingLanguageId.Id2));
    
    [HttpPut("programming-languages")]
    public async Task<IActionResult> UpdateProgrammingLanguagesInModel(IdAndIds<long, long> modelAndProgrammingLanguageIds)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.UpdateProgrammingLanguagesInModel(modelAndProgrammingLanguageIds.Id, modelAndProgrammingLanguageIds.Ids));

    [HttpPut("programming-language")]
    public async Task<IActionResult> UpdateProgrammingLanguageInModel(IdAndId<long, long> modelAndProgrammingLanguageId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.UpdateProgrammingLanguageInModel(modelAndProgrammingLanguageId.Id1, modelAndProgrammingLanguageId.Id2));
    
    [HttpDelete("programming-languages/{modelId}/{programmingLanguageId}")]
    public async Task<IActionResult> RemoveProgrammingLanguageFromModel(long modelId, long programmingLanguageId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.RemoveProgrammingLanguageFromModel(modelId, programmingLanguageId));

    [HttpDelete("programming-languages/{modelId}")]
    public async Task<IActionResult> RemoveAllProgrammingLanguagesFromModel(long modelId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.RemoveAllProgrammingLanguagesFromModel(modelId));



    [HttpPost("technologies")]
    public async Task<IActionResult> AddTechnologiesToModel(IdAndIds<long, long> modelAndTechnologyIds)
    => await ReturnOkIfEverithingIsGood(async () => await skillService.AddTechnologiesToModel(modelAndTechnologyIds.Id, modelAndTechnologyIds.Ids));

    [HttpPost("technology")]
    public async Task<IActionResult> AddTechnologyToModel(IdAndId<long, long> modelAndTechnologyId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.AddTechnologyToModel(modelAndTechnologyId.Id1, modelAndTechnologyId.Id2));

    [HttpPut("technologies")]
    public async Task<IActionResult> UpdateTechnologiesInModel(IdAndIds<long, long> modelAndTechnologyId)
    => await ReturnOkIfEverithingIsGood(async () => await skillService.UpdateTechnologiesInModel(modelAndTechnologyId.Id, modelAndTechnologyId.Ids));

    [HttpPut("technology")]
    public async Task<IActionResult> UpdateTechnologyInModel(IdAndId<long, long> modelAndTechnologyId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.UpdateTechnologyInModel(modelAndTechnologyId.Id1, modelAndTechnologyId.Id2));

    [HttpDelete("technologies/{modelId}/{technologyId}")]
    public async Task<IActionResult> RemoveTechnologyFromModel(long modelId, long technologyId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.RemoveTechnologyFromModel(modelId, technologyId));

    [HttpDelete("technologies/{modelId}")]
    public async Task<IActionResult> RemoveAllTechnologiesFromModel(long modelId)
        => await ReturnOkIfEverithingIsGood(async () => await skillService.RemoveAllTechnologiesFromModel(modelId));

}
