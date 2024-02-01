using GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;
using GofPatterns.Structural.ProxyPattern;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;

internal interface IUserInterface : IProxyComponent<EnumOperationOption, string> { }