namespace GofConsoleApp.Examples.Structural.AdapterPattern.Target;

/// <summary>
/// Target: Defines the domain-specific interface that Client uses.
/// </summary>
internal interface ITraveller
{
    string FullName { get; }
    string Address { get; }
}