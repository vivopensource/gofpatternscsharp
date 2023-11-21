using GofPattern.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInputWithOutput;

internal interface IUserInterface : IProxyComponent<EnumOperationOption, string> { }