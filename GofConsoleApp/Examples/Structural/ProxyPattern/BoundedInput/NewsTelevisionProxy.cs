using Core.Console.Interfaces;
using GofPattern.Structural.ProxyPattern;
using static GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInput.EnumNewsChannel;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInput;

internal class NewsTelevisionProxy : ProxyBoundedInput<EnumNewsChannel>, INewsTelevisionProxy
{
    public NewsTelevisionProxy(IConsoleLogger logger) : base(new NewsTelevision(logger), new[] { Acy, Uzt, Mko }) { }
}