using ITResume.Client.Managers;
using ITResume.Server.Database;
using ITResume.Shared.Models.Database.ITResumeModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ITResume.Server.Services.ITResumeManagers;

public abstract class ITResumeManager<T> : IITResumeDbModelService<T> where T : ITResumeDbModel
{
    protected readonly ITResumeContext db;
    public ITResumeManager(ITResumeContext db)
       => this.db = db;

    protected abstract DbSet<T> AllModels();
    protected virtual IQueryable<T> GetAllModels()
        => AllModels();

    public virtual async Task<T> AddModelAsync(T model)
    {
        await AllModels().AddAsync(model);
        await SaveChangesAsync();
        return model;
    }

    public virtual async Task DeleteModelAsync(long key)
    {
        T? model = await GetModelByIdAsync(key);
        if (model is not null)
        {
            AllModels().Remove(model);
            await SaveChangesAsync();
        }
    }

    public virtual async Task<IEnumerable<T>> GetAllModelsAsync()
        => await GetAllModels().ToListAsync();

    public virtual async Task<T?> GetModelByIdAsync(long key)
        => await GetAllModels().FirstOrDefaultAsync(m => m.Id == key);

    public virtual async Task UpdateModelAsync(T model)
    {
        AllModels().Update(model);
        await SaveChangesAsync();
    }

    async Task SaveChangesAsync()
        => await db.SaveChangesAsync();
}
