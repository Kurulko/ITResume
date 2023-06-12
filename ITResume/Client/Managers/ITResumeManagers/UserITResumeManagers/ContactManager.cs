using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITResume.Client.Managers.ITResumeManagers;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services.ITResumeServices.UserServices;

namespace ITResume.Client.Managers.ITResumeManagers.UserITResumeManagers;

public class ContactManager : ITResumeDbModelManager<Contact>, IContactService
{
    public ContactManager(HttpClient httpClient) : base(httpClient, "contacts") { }
}