using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using ITResume.Shared.Models.ViewModels;
using ITResume.Shared.Services;
using ITResume.Shared.Services.ITResumeServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace ITResume.Server.Controllers.ITResumeControllers.UserITResumeControllers.SkillUserModelsControllers;

public class EmployeesController : SkillUserModelsController<Employee>
{
    public EmployeesController(IEmployeeService service, IUserService userService) : base(service, userService) { }
}
