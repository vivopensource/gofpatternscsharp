using GofConsoleApp.Examples.Structural.BridgePattern.Marker;

namespace GofConsoleApp.Examples.Structural.BridgePattern;

internal class BridgePatternExampleWithMarker : BaseExample
{
    protected override bool Execute()
    {
        var emp1 = new Employee("1", "Jane", "Doe");
        var emp2 = new Employee("2", "John", "Doe");

        IProcess registerEvent = new Registration();
        IProcess taskPresentation = new TaskAssignment("Goals presentation");

        IManagement annualConference1 =
            new EventManagement("Annual conference", Logger, registerEvent, taskPresentation);
        annualConference1.Manage(emp1);

        IManagement annualConference2 = new EventManagement("Annual conference", Logger, registerEvent);
        annualConference2.Manage(emp2);

        IProcess taskSalesPitch = new TaskAssignment("Sales pitch");
        IManagement salesTravel = new TravelManagement("Sales", Logger, taskSalesPitch);
        salesTravel.Manage(emp1);

        IProcess registerTravel = new Registration();
        IProcess taskSystemUpgrade = new TaskAssignment("System upgrade");
        IManagement maintenanceTravel = new TravelManagement("Maintenance", Logger, registerTravel, taskSystemUpgrade);
        maintenanceTravel.Manage(emp2);

        return true;
    }
}

// Data
internal class Employee
{
    public Employee(string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Id { get; }

    public string FirstName { get; }

    public string LastName { get; }
}