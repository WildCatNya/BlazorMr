using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BlazorMr;

public static class Extensions
{
    public static int ToInt32(this string value)
    {
        if (int.TryParse(value, out int result))
        {
            return result;
        }
        throw new ArgumentException("Invalid string value");
    }
    public static string? GetAttributeName(this Enum enumValue)
    {
        return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
    }
}