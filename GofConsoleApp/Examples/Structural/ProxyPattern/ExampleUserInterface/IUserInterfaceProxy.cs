using GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;
using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ExampleUserInterface;

internal interface IUserInterfaceProxy : IUserInterface, IProxyBoundedAccess<EnumOperationOption, string> { }