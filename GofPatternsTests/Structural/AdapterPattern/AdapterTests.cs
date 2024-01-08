using GofConsoleApp.Examples.Structural.AdapterPattern;
using GofConsoleApp.Examples.Structural.AdapterPattern.Adaptee;
using GofConsoleApp.Examples.Structural.AdapterPattern.Target;
using NUnit.Framework;

namespace GofPatternsTests.Structural.AdapterPattern;

[TestFixture]
internal class AdapterTests
{
    [Test]
    public void AdapterTest()
    {
        // arrange
        var employee = new Employee("1", "John", "Doe", "Success Lane 1");

        // act
        ITraveller sutAdapter = new EmployeeTravellerAdapter(employee);

        // assert
        Assert.That(sutAdapter.FullName, Is.EqualTo($"{employee.FirstName} {employee.LastName}"));
        Assert.That(sutAdapter.Address, Is.EqualTo(employee.Address));
    }
}