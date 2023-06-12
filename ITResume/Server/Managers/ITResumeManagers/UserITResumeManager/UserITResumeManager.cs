using ITResume.Client.Managers;
using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.EntityFrameworkCore;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;

public abstract class UserITResumeManager<T> : ITResumeManager<T> where T : UserITResumeDbModel
{
    readonly IUserService userService;
    public UserITResumeManager(ITResumeContext db, IUserService userService) : base(db)
        => this.userService = userService;

    public override async Task AddModelAsync(T model)
    {
        model.User = await userService.GetUsedUserAsync();
        await base.AddModelAsync(model);
    }

    public override async Task UpdateModelAsync(T model)
    {
        model.User = await userService.GetUsedUserAsync();
        await base.UpdateModelAsync(model);
    }
}
