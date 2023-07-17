using Core.Logging;
using GofConsoleApp.Examples.Behavioral.Command;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Behavioral.Command;

[TestFixture]
internal class CommandInvokerTests
{
    [SetUp]
    public void Setup()
    {
        props.MockLog = new Mock<CustomLogger>(Mock.Of<ILogger>());
        props.Sut = new CommandInvokerExample(props.MockLog.Object);
    }

    [Test]
    public void Test()
    {
        #region Arrange

        const int expectedResult = 5;
        var sut = props.Sut;

        #endregion

        #region Act

        sut.DeliverPizza(3);
        sut.DeliverBurger(5);
        sut.EatBurger(6);
        sut.InvokeOrder();
        sut.EatBurger(3);
        sut.EatPizza(3);
        sut.InvokeOrder();

        #endregion

        #region Assert

        props.MockLog.Verify(m => m.LogInformation(It.IsAny<string>()), Times.Exactly(expectedResult));

        #endregion
    }

    private TestProps props;

    private struct TestProps
    {
        public CommandInvokerExample Sut { get; set; }
        public Mock<CustomLogger> MockLog { get; set; }
    }
}