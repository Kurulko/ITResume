using ITResume.Shared.Models.Database.ITResumeModels.UserModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers;

public class EmployeesController : UserITResumeDbModelsController<Employee>
{
    public EmployeesController(IEmployeeService service, IUserService userService) : base(service, userService) { }

    protected override Employee? ReturnModelWithoutCycles(Employee? model)
    {
        if (model is not null && model.User is not null)
        {
            model.User!.Employees = null;
            return model;
        }
        return model;
    }
}
