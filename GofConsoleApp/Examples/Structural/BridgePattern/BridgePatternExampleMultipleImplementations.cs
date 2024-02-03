using GofConsoleApp.Examples.Structural.BridgePattern.MultipleImplementations;

namespace GofConsoleApp.Examples.Structural.BridgePattern;

internal class BridgePatternExampleMultipleImplementations : BaseExample
{
    protected override bool Execute()
    {
        var emp1 = new Employee("1", "Jane", "Doe");
        var emp2 = new Employee("2", "John", "Doe");

        IProcess registerEvent = new Registration(Logger);
        IProcess taskPresentation = new TaskAssignment("Goals presentation", Logger);

        IManagement annualConference1 = new EventManagement("Annual conference", Logger);
        annualConference1.Add(registerEvent, taskPresentation);
        annualConference1.Execute(emp1);

        IManagement annualConference2 = new EventManagement("Annual conference", Logger);
        annualConference2.Add(registerEvent);
        annualConference2.Execute(emp2);

        IProcess taskSalesPitch = new TaskAssignment("Sales pitch", Logger);
        IManagement salesTravel = new TravelManagement("Sales", Logger);
        salesTravel.Add(taskSalesPitch);
        salesTravel.Execute(emp1);

        IProcess registerTravel = new Registration(Logger);
        IProcess taskSystemUpgrade = new TaskAssignment("System upgrade", Logger);
        IManagement maintenanceTravel = new TravelManagement("Maintenance", Logger);
        maintenanceTravel.Add(registerTravel, taskSystemUpgrade);
        maintenanceTravel.Execute(emp2);

        return annualConference1.ImplementationCount == 2 &&
               annualConference2.ImplementationCount == 1 &&
               salesTravel.ImplementationCount == 1 &&
               maintenanceTravel.ImplementationCount == 2;
    }
}