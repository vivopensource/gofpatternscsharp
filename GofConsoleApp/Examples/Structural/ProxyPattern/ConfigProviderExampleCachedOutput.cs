using Core.Extensions;
using GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderCachedOutput;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderCachedOutput.EnumConfigEnv;

namespace GofConsoleApp.Examples.Structural.ProxyPattern;

/// <summary>
/// This example uses the Cached Output approach of Proxy Pattern.
/// It loads the configuration of the respective env and it caches
/// the output for the next time.
/// </summary>
internal class ConfigProviderExampleCachedOutput : AbstractExample
{
    protected override bool Execute()
    {
        Logger.LogOptions("config environments", new[] { Dev, Prod, Test });

        var configLoader = new ConfigProviderProxy(Logger);

        ExecuteConfigLoader(configLoader);

        return true;
    }

    private void ExecuteConfigLoader(ConfigProviderProxy proxy)
    {
        while (true)
        {
            var input = AcceptInputEnum(Invalid, "env to load config");

            if (input == Invalid)
            {
                Logger.Log($"Quitting program due to input: {input}.");
                return;
            }

            var config = proxy.Process(input);

            var str = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build()
                .Serialize(config);

            Logger.Log(str);
        }
    }
}