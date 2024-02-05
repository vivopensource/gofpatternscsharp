using GofConsoleApp.Examples.Structural.BridgePattern.Implementations;
using GofConsoleApp.Examples.Structural.BridgePattern.Implementations.Single;

namespace GofConsoleApp.Examples.Structural.BridgePattern;

internal class BridgePatternExampleSingleImplementations : BaseExample
{
    protected override bool Execute()
    {
        var emp1 = new Employee("1", "Jane", "Doe");
        var emp2 = new Employee("2", "John", "Doe");

        IProcess registerEvent = new Registration(Logger);
        IManagement annualConference1 = new EventManagement("Annual conference", Logger);
        annualConference1.Add(registerEvent);
        annualConference1.Execute(emp1);

        IManagement annualConference2 = new EventManagement("Annual conference", Logger);
        annualConference2.Add(registerEvent);
        annualConference2.Execute(emp2);

        IProcess taskSalesPitch = new TaskAssignment("Sales pitch", Logger);
        IManagement salesTravel = new TravelManagement("Sales", Logger);
        salesTravel.Add(taskSalesPitch);
        salesTravel.Execute(emp1);

        IProcess taskSystemUpgrade = new TaskAssignment("System upgrade", Logger);
        IManagement maintenanceTravel = new TravelManagement("Maintenance", Logger);
        maintenanceTravel.Add(taskSystemUpgrade);
        maintenanceTravel.Execute(emp2);

        return true;
    }
}