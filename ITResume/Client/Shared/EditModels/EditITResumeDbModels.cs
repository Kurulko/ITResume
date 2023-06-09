﻿using ITResume.Shared.Models.Database;
using ITResume.Shared.Services.ITResumeServices;
using ITResume.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ITResume.Client.Shared.EditModels;

public abstract partial class EditITResumeDbModels<TModel>
     where TModel : ITResumeDbModel
{
}