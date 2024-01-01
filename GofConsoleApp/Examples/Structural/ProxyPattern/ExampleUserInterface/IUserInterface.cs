using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;

internal interface IUserInterface : IProxyComponent<EnumOperationOption, string> { }