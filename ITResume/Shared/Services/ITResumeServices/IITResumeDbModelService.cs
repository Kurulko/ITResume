using ITResume.Shared.Models.Database.ITResumeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services.ITResumeServices;

public interface IITResumeDbModelService<T> : IDbModelService<T, long> where T : ITResumeDbModel
{
}
