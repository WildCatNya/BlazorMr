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
}