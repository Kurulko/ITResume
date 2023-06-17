﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITResume.Client.Managers.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;
using ITResume.Shared.Services.ITResumeServices.UniqueNameServices;
using ITResume.Client.Managers.ITResumeManagers.UniqueNameManagers;

namespace ITResume.Client.Managers.ITResumeManagers.UniqueNameServices;

public class ProgrammingLanguageManager : UniqueNameManager<ProgrammingLanguage>, IProgrammingLanguageService
{
    public ProgrammingLanguageManager(HttpClient httpClient) : base(httpClient, "programming-languages") { }
}