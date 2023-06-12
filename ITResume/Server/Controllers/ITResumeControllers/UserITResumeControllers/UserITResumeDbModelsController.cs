using HtmlAgilityPack;
using ITResume.Shared.Models.Database;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers;

[Authorize]
public abstract class UserITResumeDbModelsController<T> : ITResumeDbModelsController<T> where T : UserITResumeDbModel
{
    protected readonly IUserService userService;
    public UserITResumeDbModelsController(IDbModelService<T, long> service, IUserService userService) : base(service)
        => this.userService = userService;

    protected abstract T? ReturnModelWithoutCycles(T? model);

    public override async Task<IEnumerable<T>> GetModelsAsync()
        => (await base.GetModelsAsync()).Select(m => ReturnModelWithoutCycles(m)!);

    public override async Task<T?> GetModelByIdAsync(long key)
    {
        T? model = await base.GetModelByIdAsync(key);
        await CheckModelWithCurrentUser(model);
        return ReturnModelWithoutCycles(model);
    }
    
    public override async Task<IActionResult> UpdateModelAsync(T model)
    {
        await CheckModelWithCurrentUser(model);
        return await base.UpdateModelAsync(model);
    }
    
    public override async Task<IActionResult> DeleteModelAsync(long key)
    {
        T? model = await GetModelByIdAsync(key);
        await CheckModelWithCurrentUser(model);
        return await base.DeleteModelAsync(key);
    }

    async Task CheckModelWithCurrentUser(T? model)
    {
        if (model is not null)
        {
            User _user;

            User currentUser = (await userService.GetUserByClaimsAsync(User))!;
            string? usedUserId = currentUser.UsedUserId;

            if (string.IsNullOrEmpty(usedUserId))
                _user = currentUser;
            else
            {
                User? usedUser = await userService.GetModelByIdAsync(usedUserId);
                _user =  usedUser is null ? currentUser : usedUser;
            }

            if (model.User is not null && model.User!.Id != _user.Id)
                throw new Exception("Access to this resource is denied");
        }
    }
}
