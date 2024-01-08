using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Core.Extensions;

internal static class ObjectExtensions
{
    public static string ToYamlString(this object obj)
    {
        return new SerializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build().Serialize(obj);
    }
}