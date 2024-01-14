using Core.Extensions;
using GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderComponents;
using GofPatterns.Structural.ProxyPattern;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderComponents.EnumConfigEnv;

namespace GofConsoleApp.Examples.Structural.ProxyPattern;

/// <summary>
/// This example uses the Cached Output approach of Proxy Pattern.
/// It loads the configuration of the respective env and it caches
/// the output for the next time.
/// </summary>
internal class ConfigProviderExampleCachedOutput : BaseExample
{
    protected override bool Execute()
    {
        Logger.Log("config environments", new[] { Dev, Prod, Test });

        // Pattern Definition
        var component = new ConfigProvider(Logger);
        var proxy = new ProxyCachedOutput<EnumConfigEnv, Config>(component);

        ExecuteConfigLoader(proxy);

        return true;
    }

    private void ExecuteConfigLoader(ProxyCachedOutput<EnumConfigEnv, Config> proxy)
    {
        while (true)
        {
            var input = AcceptInputEnum(Invalid, "env to load config");

            if (input == Invalid)
            {
                Logger.Log($"Quitting program due to input: {input}.");
                return;
            }

            // Pattern Execution
            var config = proxy.Process(input);

            var str = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build()
                .Serialize(config);

            Logger.Log(str);
        }
    }
}