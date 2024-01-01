using Core.Console.Interfaces;
using GofPatterns.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannel.EnumNewsChannel;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannel;

internal class NewsChannelProxy : ProxyBoundedAccess<EnumNewsChannel>, INewsChannelProxy
{
    public NewsChannelProxy(IConsoleLogger logger) : base(new NewsChannel(logger), new[] { Acy, Uzt, Mko }) { }
}