namespace GofConsoleApp.Examples.Structural.BridgePattern;

internal class BridgePatternExample : BaseExample
{
    protected override bool Execute()
    {
        var emp1 = new Employee("1", "Jane", "Doe");
        var emp2 = new Employee("2", "John", "Doe");

        IProcessEmployee register = new Register();
        IManagement yearlyEvent = new EventManagement("Yearly Event", register, Logger);
        yearlyEvent.Manage(emp1);
        yearlyEvent.Manage(emp2);

        IProcessEmployee taskSalesPitch = new TaskAssignment("Sales pitch");
        IManagement salesTravel = new TravelManagement("Sales", taskSalesPitch, Logger);
        salesTravel.Manage(emp1);

        IProcessEmployee taskSystemUpgrade = new TaskAssignment("System upgrade");
        IManagement maintenanceTravel = new TravelManagement("Maintenance", taskSystemUpgrade, Logger);
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