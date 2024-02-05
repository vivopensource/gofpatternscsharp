namespace GofConsoleApp.Examples.Structural.AdapterPattern.Adaptee;

internal class Employee : IEmployee
{
    public Employee(string id, string firstName, string lastName, string address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public string Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Address { get; }
}