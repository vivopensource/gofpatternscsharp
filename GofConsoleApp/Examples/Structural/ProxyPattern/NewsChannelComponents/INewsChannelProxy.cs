using GofPatterns.Structural.ProxyPattern;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannelComponents;

internal interface INewsChannelProxy : INewsChannel, IProxyBoundedAccess<EnumNewsChannel> { }