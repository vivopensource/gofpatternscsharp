namespace GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderComponents;

// ReSharper disable UnusedAutoPropertyAccessor.Global
internal class Config
{
    public EnumConfigEnv EnvType { get; set; }

    public string DatabaseConnection { get; set; } = string.Empty;

    public string SftpConnection { get; set; } = string.Empty;
}