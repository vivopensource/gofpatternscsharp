using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral.CommandPattern.CommandInvoker;

[TestFixture]
internal class OnlineShopTests : BaseTest
{
    [Test]
    public void ExecuteCommands_DoesNothingIfNoCommandProvided_ReturnsInt()
    {
        // act
        var onlineShop = new OnlineShop(MockConsoleLogger.Object);

        // act
        var actualResult = onlineShop.CheckOut();

        // assert
        Assert.That(actualResult, Is.Zero);
    }
    
}