using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services.ITResumeServices.UniqueNameServices;

public interface IUniqueNameService<T> : IITResumeDbModelService<T> where T : UniqueNameModel
{
    Task<T?> GetModelByUniqueNameAsync(string uniqueName);
}
