using ITResume.Client.Managers;
using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ITResume.Server.Managers.ITResumeManagers.UserITResumeManager;

public abstract class UserITResumeManager<T> : ITResumeManager<T> where T : UserITResumeDbModel
{
    readonly IUserService userService;
    public UserITResumeManager(ITResumeContext db, IUserService userService) : base(db)
        => this.userService = userService;

    public override async Task<T> AddModelAsync(T model)
    {
        model.User = await userService.GetUsedUserAsync();
        return await base.AddModelAsync(model);
    }

    public override async Task UpdateModelAsync(T model)
    {
        model.User = await userService.GetUsedUserAsync();
        await base.UpdateModelAsync(model);
    }

    protected virtual async Task AddForeignModelToModel(string tableName, string modelIdName, string foreignModelIdName, object modelIdValue, object foreignModelIdValue)
    {
        string sqlStr = @$"INSERT INTO {tableName} ({modelIdName}, {foreignModelIdName}) 
                    VALUES (@modelIdValue, @foreignModelIdValue)";
        var parameters = new SqlParameter[]
        {
            new("@modelIdValue", modelIdValue),
            new("@foreignModelIdValue", foreignModelIdValue)
        };

        await db.Database.ExecuteSqlRawAsync(sqlStr, parameters);
    }

    protected virtual async Task UpdateForeignModelInModel(string tableName, string modelIdName, string foreignModelIdName, object modelIdValue, object foreignModelIdValue)
    {
        await RemoveAllForeignModelsFromModel(tableName, modelIdName, modelIdValue);
        await AddForeignModelToModel(tableName, modelIdName, foreignModelIdName, modelIdValue, foreignModelIdValue);
    }

    protected virtual async Task UpdateForeignModelsInModel(string tableName, string modelIdName, string foreignModelIdName, object modelIdValue, IEnumerable<object> foreignModelIdValues)
    {
        await RemoveAllForeignModelsFromModel(tableName, modelIdName, modelIdValue);
        foreach (var foreignModelIdValue in foreignModelIdValues)
            await AddForeignModelToModel(tableName, modelIdName, foreignModelIdName, modelIdValue, foreignModelIdValue);
    }

    protected virtual async Task RemoveForeignModelFromModel(string tableName, string modelIdName, string foreignModelIdName, object modelIdValue, object foreignModelIdValue)
    {
        string sqlStr = $"DELETE FROM {tableName} WHERE {foreignModelIdName} = @foreignModelIdValue AND {modelIdName} = @modelIdValue";
        var parameters = new SqlParameter[]
        {
            new ("@foreignModelIdValue", foreignModelIdValue),
            new("@modelIdValue", modelIdValue)
        };

        await db.Database.ExecuteSqlRawAsync(sqlStr, parameters);
    }

    protected virtual async Task RemoveAllForeignModelsFromModel(string tableName, string modelIdName, object modelIdValue)
    {
        string sqlStr = $"DELETE FROM {tableName} WHERE {modelIdName} = @modelIdValue";
        SqlParameter parameter = new("@modelIdValue", modelIdValue);

        await db.Database.ExecuteSqlRawAsync(sqlStr, parameter);
    }

}
