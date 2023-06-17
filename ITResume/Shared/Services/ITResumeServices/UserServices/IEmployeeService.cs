using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITResume.Shared.Services.ITResumeServices.UserServices;

public interface IEmployeeService : IITResumeDbModelService<Employee>, ISkillService<Employee> { }
