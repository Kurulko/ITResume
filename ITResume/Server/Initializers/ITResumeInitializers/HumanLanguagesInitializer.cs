using Microsoft.Data.SqlClient;
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
    public static IEnumerable<HumanLanguage> GetSomeHumanLanguages()
        => languages.Distinct().Select(l => new HumanLanguage() { Name = l });

    static string[] languages = {
        "English",
        "Spanish",
        "French",
        "German",
        "Italian",
        "Portuguese",
        "Russian",
        "Chinese",
        "Japanese",
        "Korean",
        "Arabic",
        "Hindi",
        "Bengali",
        "Punjabi",
        "Urdu",
        "Turkish",
        "Dutch",
        "Swedish",
        "Norwegian",
        "Danish",
        "Finnish",
        "Greek",
        "Polish",
        "Czech",
        "Hungarian",
        "Romanian",
        "Thai",
        "Indonesian",
        "Vietnamese",
        "Hebrew",
        "Swahili",
        "Kiswahili",
        "Tagalog",
        "Malay",
        "Kazakh",
        "Ukrainian",
        "Bulgarian",
        "Slovak",
        "Slovenian",
        "Croatian",
        "Serbian",
        "Macedonian",
        "Albanian",
        "Estonian",
        "Latvian",
        "Lithuanian",
        "Icelandic",
        "Maltese",
        "Farsi",
        "Persian",
        "Sinhala",
        "Tamil",
        "Telugu",
        "Kannada",
        "Marathi",
        "Gujarati",
        "Odia",
        "Afrikaans",
        "Zulu",
        "Xhosa",
        "Sotho",
        "Tswana",
        "Swazi",
        "Ndebele",
        "Sesotho",
        "Tsonga"
    };

    //static string GetEnglishLanguageName(CultureInfo culture)
    //{
    //    try
    //    {
    //        var englishCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
    //        var englishName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(culture.NativeName);

    //        if (englishName == culture.DisplayName)
    //            englishName = englishCulture.DisplayName;

    //        return englishName;
    //    }
    //    catch (CultureNotFoundException)
    //    {
    //        return culture.DisplayName;
    //    }
    //}


    //public static IEnumerable<HumanLanguage> GetAllHumanLanguages()
    //{
    //    SortedSet<string> languagesStr = new();

    //    foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
    //        if (culture.LCID != CultureInfo.InvariantCulture.LCID && !culture.IsNeutralCulture)
    //            languagesStr.Add(GetEnglishLanguageName(culture));


    //    IEnumerable<HumanLanguage> languages = languagesStr.Distinct().Select(languageStr => new HumanLanguage() { Name = languageStr });
    //    return languages;
    //}
}
