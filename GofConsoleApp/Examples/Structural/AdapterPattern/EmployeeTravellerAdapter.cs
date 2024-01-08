using GofConsoleApp.Examples.Structural.AdapterPattern.Adaptee;
using GofConsoleApp.Examples.Structural.AdapterPattern.Target;
using GofPatterns.Structural.AdapterPattern;

namespace GofConsoleApp.Examples.Structural.AdapterPattern;

internal class EmployeeTravellerAdapter : IAdapter<IEmployee, ITraveller>, ITraveller
{
    public EmployeeTravellerAdapter(IEmployee adaptee)
    {
        FullName = $"{adaptee.FirstName} {adaptee.LastName}";
        Address = adaptee.Address;
    }

    public string FullName { get; }
    public string Address { get; }
}