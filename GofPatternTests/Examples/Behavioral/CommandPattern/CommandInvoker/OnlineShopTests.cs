using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral.CommandPattern.CommandInvoker;

[TestFixture]
internal class OnlineShopTests
{
    [Test]
    public void ExecuteCommands_DoesNothingIfNoCommandProvider()
    {
        // act
        var onlineShop = new OnlineShop();

        // act
        var actualResult = onlineShop.ExecuteCommands();

        // assert
        Assert.That(actualResult, Is.Zero);
    }
    
}