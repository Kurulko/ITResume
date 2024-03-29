﻿using ITResume.Shared.Models.Database;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace ITResume.Client.Shared.EditModels.Complex;

public partial class ComplexEditDbModels<TModel, TKey> 
     where TModel : class, IDbModel
{

}