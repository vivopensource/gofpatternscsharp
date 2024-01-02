using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannelComponents;

internal interface INewsChannel : IProxyComponent<EnumNewsChannel> { }