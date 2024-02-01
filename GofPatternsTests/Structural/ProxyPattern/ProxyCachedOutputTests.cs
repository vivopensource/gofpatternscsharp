using GofPatterns.Structural.ProxyPattern;
using NUnit.Framework;

namespace GofPatternsTests.Structural.ProxyPattern;

[TestFixture]
internal class ProxyCachedOutputTests
{
    [TestCase(new[] { EnumConfigEnv.Dev, EnumConfigEnv.Prod }, EnumConfigEnv.Dev, true)]
    public void Process_LoadsAndCachesData_ReturnsCachedData(EnumConfigEnv[] envInputs, EnumConfigEnv env,
        bool isCached)
    {
        // arrange
        var component = new ConfigProvider();
        var sut = new ProxyCachedOutput<EnumConfigEnv, Config>(component);

        // act
        foreach (var envInput in envInputs)
            sut.Process(envInput);

        var conf = sut.Process(env);

        // assert
        Assert.That(sut.Cache.ContainsKey(env), Is.EqualTo(isCached));
        Assert.That(sut.Cache[env].EnvType, Is.EqualTo(conf.EnvType));
        Assert.That(sut.Cache[env].DatabaseConnection, Is.EqualTo(conf.DatabaseConnection));
    }

    [Test]
    public void Process_NotLoadedDataIsNotCached()
    {
        // arrange
        var component = new ConfigProvider();
        var sut = new ProxyCachedOutput<EnumConfigEnv, Config>(component);

        // act
        sut.Process(EnumConfigEnv.Dev);

        // assert
        Assert.That(sut.Cache.ContainsKey(EnumConfigEnv.Prod), Is.False);
    }

    public enum EnumConfigEnv
    {
        Dev,
        Prod
    }

    private class Config
    {
        public EnumConfigEnv EnvType { get; init; }

        public string DatabaseConnection { get; init; } = string.Empty;
    }

    private class ConfigProvider : IProxyComponent<EnumConfigEnv, Config>
    {
        public Config Process(EnumConfigEnv input)
        {
            return new Config
            {
                EnvType = input,
                DatabaseConnection = input + "-DatabaseConnection"
            };
        }
    }
}