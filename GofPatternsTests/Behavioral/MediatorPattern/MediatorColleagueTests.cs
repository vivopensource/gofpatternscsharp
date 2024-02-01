using Core.Console;
using GofConsoleApp.Examples.Behavioral.MediatorPattern;
using GofPatterns.Behavioral.MediatorPattern;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.MediatorPattern;

[TestFixture]
internal class MediatorColleagueTests : BaseTest
{
    [Test]
    public void Send_CallsAnotherGivenColleague()
    {
        // arrange
        var mockPerson1Logger = new Mock<ConsoleLogger>(Mock.Of<ILogger>());
        var mockPerson2Logger = new Mock<ConsoleLogger>(Mock.Of<ILogger>());

        var chatroom = new Mediator<string, string>();
        IMediatorColleague<string, string> sutPerson1 = new ChatPerson("Person1", chatroom, mockPerson1Logger.Object);
        IMediatorColleague<string, string> sutPerson2 = new ChatPerson("Person2", chatroom, mockPerson2Logger.Object);

        // act
        sutPerson1.Send(sutPerson2.Identifier, $"Hello from {sutPerson1.Identifier}");
        sutPerson2.Send(sutPerson1.Identifier, $"Hello from {sutPerson2.Identifier}");

        // assert
        mockPerson1Logger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        mockPerson2Logger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }
}