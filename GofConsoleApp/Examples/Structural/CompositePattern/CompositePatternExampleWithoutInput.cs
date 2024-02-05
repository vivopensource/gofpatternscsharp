namespace GofConsoleApp.Examples.Structural.CompositePattern;

internal class CompositePatternExampleWithoutInput : BaseExample
{
    protected override bool Execute()
    {
        // Installation team
        IResource employeeJack = new Employee("Jack", Logger);
        IResource employeeJill = new Employee("Jill", Logger);
        var installers = new Team("Product Installation", Logger);
        installers.Add(employeeJack, employeeJill);

        // Specialist team
        IResource employeeJohn = new Employee("John", Logger);
        IResource employeeJane = new Employee("Jane", Logger);
        var specialists = new Team("Product Specialist", Logger);
        specialists.Add(employeeJohn, employeeJane);

        // Support team
        var support = new Team("Product Support", Logger);
        support.Add(specialists, installers);
        support.Process();

        return true;
    }
}