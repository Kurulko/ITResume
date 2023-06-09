using ITResume.Client.Models;

namespace ITResume.Client.Extensions;

public static class EnumExtensions
{
    public static IEnumerable<DropDownListItem> ConvertToDropDownSource<T>(string initialText, string initialValue)
         where T : struct, Enum
    {
        IList<DropDownListItem> list = new List<DropDownListItem>();

        if (!string.IsNullOrEmpty(initialValue) || !string.IsNullOrEmpty(initialText))
            list.Add(new DropDownListItem(initialText, initialValue));

        var values = Enum.GetValues<T>();
        var names = Enum.GetNames<T>();
        for (int i = 0; i < names.Length; i++)
            list.Add(new DropDownListItem(names[i], values[i].ToString()));

        return list;
    }
}