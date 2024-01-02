namespace GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderComponents;

// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

internal class Config
{
    public EnumConfigEnv EnvType { get; set; }

    public string DatabaseConnection { get; set; }

    public string SftpConnection { get; set; }
}