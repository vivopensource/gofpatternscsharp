using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.UserInterfaceComponents;

internal interface IUserInterfaceProxy : IUserInterface, IProxyBoundedAccess<EnumOperationOption, string> { }