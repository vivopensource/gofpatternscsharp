using Core.Console;
using GofConsoleApp.Examples.Behavioral.MediatorPattern;
using GofPatterns.Behavioral.MediatorPattern;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.MediatorPattern;

[TestFixture]
internal class MediatorTests : BaseTest
{
    [Test]
    public void Send_CallsAnotherGivenColleague()
    {
        // arrange
        var mockPerson1Logger = new Mock<ConsoleLogger>(Mock.Of<ILogger>());
        var mockPerson2Logger = new Mock<ConsoleLogger>(Mock.Of<ILogger>());

        var sut = new Mediator<string, string>();
        var person1 = new ChatPerson( "Person1", sut, mockPerson1Logger.Object);
        var person2 = new ChatPerson( "Person2", sut, mockPerson2Logger.Object);

        // act
        sut.Send(person1.Identifier, "Welcome in chatroom!");
        sut.Send(person2.Identifier, "Welcome in chatroom!");

        // assert
        mockPerson1Logger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        mockPerson2Logger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        
    }
}