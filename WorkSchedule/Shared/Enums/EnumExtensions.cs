using System.ComponentModel;
using System.Reflection;

namespace Shared.Enums;

public static class EnumExtensions
{
    public static string? GetDescription<T>(this T? source) where T : Enum
    {
        if (source == null)
            return null;

        FieldInfo? fi = source.GetType().GetField(source?.ToString() ?? string.Empty);

        if (fi == null)
            return null;

        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;

        return source?.ToString() ?? string.Empty;
    }

    public static T? GetValueFromDescription<T>(this string description) where T : Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                if (attribute.Description == description)
                    return (T?)field.GetValue(null);
            else
            {
                if (field.Name == description)
                    return (T?)field.GetValue(null);
            }
        }
        return default;
    }
}
