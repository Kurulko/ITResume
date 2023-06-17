using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITResume.Shared.Models.Database.ITResumeModels.UserModels.SkillUserModels;

namespace ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

public class Company : UniqueNameModel
{
    public string? Description { get; set; }

    [Display(Name = "Start")]
    public DateTime StartWorking { get; set; }

    [Display(Name = "End")]
    public DateTime? FinishWorking { get; set; }

    public long? CountryId { get; set; }
    public Country? Country { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }

    [NotMapped]
    public IEnumerable<ProgrammingLanguage>? ProgrammingLanguages => GetAllUniqueNameModels(e => e.ProgrammingLanguages);

    [NotMapped]
    public IEnumerable<Technology>? Technologies => GetAllUniqueNameModels(e =>  e.Technologies);

    IEnumerable<T>? GetAllUniqueNameModels<T>(Func<Employee, IEnumerable<T>?> getModelsFromEmployee) where T : UniqueNameModel
    {
        if (Employees is null)
            return default;

        List<T> allUniqueNameModels = new();

        foreach (Employee employee in Employees)
        {
            var models = getModelsFromEmployee(employee);
            if (models is not null)
                allUniqueNameModels.AddRange(models);
        }

        return allUniqueNameModels.DistinctBy(pl => pl.Name);
    }
}
