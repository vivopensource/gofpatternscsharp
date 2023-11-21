/*
internal static class ObjectExtensions
{
    public static bool IsEqualTo(this object obj1, object? obj2, string propName)
    {
        if (obj2 is null || obj1.GetType() != obj2.GetType())
            return false;

        var prop1 = obj1.GetType().GetProperties().First(x => x.Name.Equals(propName));
        var prop2 = obj2.GetType().GetProperties().First(x => x.Name.Equals(propName));

        var val1 = prop1.GetValue(obj1);
        var val2 = prop2.GetValue(obj2);

        return val1!.Equals(val2);
    }
}
*/