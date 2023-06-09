using ITResume.Shared.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services;

public interface IDbModelService<T,K> where T : IDbModel
{
    Task<IEnumerable<T>> GetAllModelsAsync();
    Task<T?> GetModelByIdAsync(K key);
    Task UpdateModelAsync(T model);
    Task AddModelAsync(T model);
    Task DeleteModelAsync(K key);
}
