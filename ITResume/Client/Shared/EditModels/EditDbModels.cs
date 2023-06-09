using ITResume.Shared.Models.Database;

namespace ITResume.Client.Shared.EditModels;

public abstract partial class EditDbModels<TModel, TKey>
     where TModel : class, IDbModel
{

}
