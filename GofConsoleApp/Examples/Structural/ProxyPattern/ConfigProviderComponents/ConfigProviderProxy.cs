using Core.Console.Interfaces;
using GofPatterns.Structural.ProxyPattern;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderComponents;

internal class ConfigProviderProxy : ProxyCachedOutput<EnumConfigEnv, Config>
{
    private readonly IConsoleLogger logger;

    public ConfigProviderProxy(IConsoleLogger logger) : base(new ConfigProvider(logger))
    {
        this.logger = logger;
    }

    public new Config Process(EnumConfigEnv input)
    {
        if (Cache.ContainsKey(input))
            logger.Log($"Loading '{input}' from cache.");

        return base.Process(input);
    }
}