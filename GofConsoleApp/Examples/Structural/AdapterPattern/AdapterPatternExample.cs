using Core.Extensions;
using GofConsoleApp.Examples.Structural.AdapterPattern.Adaptee;
using GofConsoleApp.Examples.Structural.AdapterPattern.Target;

namespace GofConsoleApp.Examples.Structural.AdapterPattern;

internal class AdapterPatternExample : BaseExample
{
    protected override bool Execute()
    {
        IEmployee employee = new Employee("1", "John", "Doe", "Success Lane 1");
        Logger.Log($"Employee ({employee.Id}):");
        Logger.Log(employee.ToYamlString());

        ITraveller sutAdapter = new EmployeeTravellerAdapter(employee);
        Logger.Log("Traveller information:");
        Logger.Log(sutAdapter.ToYamlString());

        return true;
    }
}