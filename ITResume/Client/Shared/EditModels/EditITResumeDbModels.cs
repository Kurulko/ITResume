using ITResume.Shared.Services.ITResumeServices;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Components;
using ITResume.Shared.Models.Database.ITResumeModels;

namespace ITResume.Client.Shared.EditModels;

public abstract partial class EditITResumeDbModels<TModel>
     where TModel : ITResumeDbModel
{
}
