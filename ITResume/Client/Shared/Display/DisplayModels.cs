using ITResume.Shared.Models.Database;

namespace ITResume.Client.Shared.Display;

public partial class DisplayModels<TModel, TKey>
     where TModel : class, IDbModel 
{

}
