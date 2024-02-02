namespace GofConsoleApp.Examples.Structural.AdapterPattern.Adaptee;

/// <summary>
/// Adaptee: Defines an existing interface that needs adapting.
/// </summary>
internal interface IEmployee
{
    string Id { get; }

    string FirstName { get; }

    string LastName { get; }

    string Address { get; }
}