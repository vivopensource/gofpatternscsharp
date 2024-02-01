using GofPatterns.Structural.ProxyPattern;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannelComponents;

internal interface INewsChannel : IProxyComponent<EnumNewsChannel> { }