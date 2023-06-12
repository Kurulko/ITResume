using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class ContactsController : UserITResumeDbModelsController<Contact>
{
    public ContactsController(IContactService service, IUserService userService) : base(service, userService) { }

    protected override Contact? ReturnModelWithoutCycles(Contact? model)
    {
        if (model is not null && model.User is not null)
        {
            model.User!.Contact = null;
            return model;
        }
        return model;
    }
}
