using ITResume.Server.Database;
using ITResume.Server.Services.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ITResume.Server.Managers.ITResumeManagers.UniqueNameManagers;

public abstract class UniqueNameManager<T> : ITResumeManager<T>, IUniqueNameService<T>  where T : UniqueNameModel
{
    public UniqueNameManager(ITResumeContext db) : base(db) { }

    public async Task<T?> GetModelByUniqueNameAsync(string uniqueName)
        => await GetAllModels().FirstOrDefaultAsync(m => m.Name == uniqueName);
}
