using ITResume.Server.Initializers.ITResumeInitializers;
using ITResume.Shared.Models.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITResume.Server.Database;

public class ITResumeContext : IdentityDbContext<User, Role, string>
{
    public DbSet<Technology> Technologies { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; } = null!;
    public DbSet<HumanLanguage> HumanLanguages { get; set; } = null!;
    public DbSet<ForeignLanguage> ForeignLanguages { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Education> Educations { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Achievement> Achievements { get; set; } = null!;
    public DbSet<UserDetails> UsersDetails { get; set; } = null!;


    public ITResumeContext(DbContextOptions<ITResumeContext> opts) : base(opts)
        => Database.EnsureCreated();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var countries = CountriesInitializer.GetAllCountries();
        builder.Entity<Country>().HasData(AddValueForId(countries));

        var humanLanguages = HumanLanguagesInitializer.GetAllHumanLanguages();
        builder.Entity<HumanLanguage>().HasData(AddValueForId(humanLanguages));

        var programmingLanguages = ProgrammingLanguagesInitializer.GetAllProgrammingLanguages().Result;
        builder.Entity<ProgrammingLanguage>().HasData(AddValueForId(programmingLanguages));
    }

    IEnumerable<ITResumeDbModel> AddValueForId(IEnumerable<ITResumeDbModel> models)
    {
        var newModels = models.ToList();

        for (int i = 0; i < newModels.Count; i++)
            newModels[i].Id = i + 1;

        return newModels;
    }
}
