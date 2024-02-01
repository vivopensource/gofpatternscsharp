using GofPatterns.Structural.ProxyPattern;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;

internal interface IUserInterfaceProxy : IUserInterface, IProxyBoundedAccess<EnumOperationOption, string> { }