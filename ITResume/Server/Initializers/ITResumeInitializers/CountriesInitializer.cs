using ITResume.Shared.Models.Database;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;

namespace ITResume.Server.Initializers.ITResumeInitializers;

public class CountriesInitializer
{
    public static IEnumerable<Country> GetAllCountries()
    {
        SortedSet<string> countriesStr = new();

        foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            RegionInfo region = new RegionInfo(culture.Name);
            countriesStr.Add(region.EnglishName);
        }

        IEnumerable<Country> countries = countriesStr.Select(countryStr => new Country() { Name = countryStr });
        return countries;
    }
}
