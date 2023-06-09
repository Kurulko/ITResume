using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace ITResume.Client.Shared.EditModels.Simple;

public partial class SimpleEditDbModels<TModel, TKey> 
     where TModel : class, IDbModel 
{

}