namespace Core.Extensions;

internal static class EnumExtensions
{
    public static T ToEnum<T>(this string value, T defaultValue)
    {
        try
        {
            if (int.TryParse(value, out _))
                return defaultValue;

            return (T)Enum.Parse(typeof(T), value, true);
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
}