using GofPattern.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInput;

internal interface INewsTelevisionProxy : INewsTelevision, IProxyBoundedInput<EnumNewsChannel> { }