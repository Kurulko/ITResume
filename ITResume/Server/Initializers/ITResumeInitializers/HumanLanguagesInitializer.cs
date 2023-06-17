﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Security.Policy;
using ITResume.Shared.Models.Database.ITResumeModels.UniqueNameModels;

namespace ITResume.Server.Initializers.ITResumeInitializers;

public class HumanLanguagesInitializer
{
    static string GetEnglishLanguageName(CultureInfo culture)
    {
        try
        {
            var englishCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            var englishName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(culture.NativeName);

            if (englishName == culture.DisplayName)
                englishName = englishCulture.DisplayName;

            return englishName;
        }
        catch (CultureNotFoundException)
        {
            return culture.DisplayName;
        }
    }


    public static IEnumerable<HumanLanguage> GetAllHumanLanguages()
    {
        SortedSet<string> languagesStr = new();

        foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
            if (culture.LCID != CultureInfo.InvariantCulture.LCID && !culture.IsNeutralCulture)
                languagesStr.Add(GetEnglishLanguageName(culture));


        IEnumerable<HumanLanguage> languages = languagesStr.Distinct().Select(languageStr => new HumanLanguage() { Name = languageStr });
        return languages;
    }
}
