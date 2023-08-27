using GofPattern.Structural.ProxyPattern;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.CachedOutput;

internal class Example : AbstractExample
{
    protected override void Steps()
    {
        var configProvider = new ConfigProvider();
        IProxyComponent<ConfigEnv, Config> configLoader = new ConfigLoader(configProvider);

        while (true)
        {
            var input = InputReader.AcceptInput();
            Enum.TryParse(input, out ConfigEnv inputType);

            if (inputType != ConfigEnv.Invalid)
                return;

            var config = configLoader.Process(inputType);

            var str = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build()
                .Serialize(config);

            Logger.Log(str);
        }
    }
}

internal class Config
{
    public ConfigEnv Env { get; set; }
    public string DatabaseConnection { get; set; }
    public string SftpConnection { get; set; }
}

internal enum ConfigEnv
{
    Dev,
    Prod,
    Test,
    Invalid
}

internal class ConfigProvider : IProxyComponent<ConfigEnv, Config>
{
    public Config Process(ConfigEnv input)
    {
        return new Config
        {
            Env = input,
            DatabaseConnection = input + "-DatabaseConnection",
            SftpConnection = input + "-SftpConnection"
        };
    }
}

internal class ConfigLoader : ProxyCachedOutput<ConfigEnv, Config>
{
    public ConfigLoader(IProxyComponent<ConfigEnv, Config> component) : base(component) { }
}