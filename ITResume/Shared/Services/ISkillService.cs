using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services;

public interface ISkillService<T> where T : SkillUserITResumeDbModel
{
    Task AddProgrammingLanguageToModel(long modelId, long programmingLanguageId);
    Task AddProgrammingLanguagesToModel(long modelId, IEnumerable<long> programmingLanguageIds);
    Task UpdateProgrammingLanguageInModel(long modelId, long programmingLanguageId);
    Task UpdateProgrammingLanguagesInModel(long modelId, IEnumerable<long> programmingLanguageIds);
    Task RemoveProgrammingLanguageFromModel(long modelId, long programmingLanguageId);
    Task RemoveProgrammingLanguagesFromModel(long modelId, IEnumerable<long> programmingLanguageIds);
    Task RemoveAllProgrammingLanguagesFromModel(long modelId);
    Task AddTechnologyToModel(long modelId, long technologyId);
    Task AddTechnologiesToModel(long modelId, IEnumerable<long> technologyIds);
    Task UpdateTechnologyInModel(long modelId, long technologyId);
    Task UpdateTechnologiesInModel(long modelId, IEnumerable<long> technologyIds);
    Task RemoveTechnologyFromModel(long modelId, long technologyId);
    Task RemoveTechnologiesFromModel(long modelId, IEnumerable<long> technologyIds);
    Task RemoveAllTechnologiesFromModel(long modelId);
}
