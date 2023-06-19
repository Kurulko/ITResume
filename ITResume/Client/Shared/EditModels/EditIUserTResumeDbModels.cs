using ITResume.Shared.Services.ITResumeServices;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Components;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;

namespace ITResume.Client.Shared.EditModels;

public abstract class EditUserITResumeDbModels<TModel> : EditITResumeDbModels<TModel>
     where TModel : UserITResumeDbModel
{
    [Parameter]
    public Func<IUserService, Task<IEnumerable<TModel>>> GetModels { get; set; } = null!;
}
