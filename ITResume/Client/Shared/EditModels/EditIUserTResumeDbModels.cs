using ITResume.Shared.Services.ITResumeServices;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Components;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;

namespace ITResume.Client.Shared.EditModels;

public abstract partial class EditUserITResumeDbModels<TModel>
     where TModel : UserITResumeDbModel
{
}
