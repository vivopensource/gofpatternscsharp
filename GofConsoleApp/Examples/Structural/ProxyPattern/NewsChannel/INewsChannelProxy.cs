using GofPattern.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannel;

internal interface INewsChannelProxy : INewsChannel, IProxyBoundedInput<EnumNewsChannel> { }