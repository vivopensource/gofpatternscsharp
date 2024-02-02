using GofConsoleApp.Examples.Structural.AdapterPattern.Adaptee;
using GofConsoleApp.Examples.Structural.AdapterPattern.Target;
using GofPatterns.Structural.AdapterPattern;

namespace GofConsoleApp.Examples.Structural.AdapterPattern;

internal class EmployeeTravellerAdapter : IAdapter<Adaptee.IEmployee, ITraveller>, ITraveller
{
    public EmployeeTravellerAdapter(Adaptee.IEmployee adaptee)
    {
        FullName = $"{adaptee.FirstName} {adaptee.LastName}";
        Address = adaptee.Address;
    }

    public string FullName { get; }
    public string Address { get; }
}