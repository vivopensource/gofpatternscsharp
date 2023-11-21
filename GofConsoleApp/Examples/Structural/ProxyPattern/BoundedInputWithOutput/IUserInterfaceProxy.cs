using GofPattern.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;

internal interface IUserInterfaceProxy : IUserInterface, IProxyBoundedInput<EnumOperationOption, string> { }