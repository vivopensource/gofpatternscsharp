using GofConsoleApp.Examples.Behavioral.ObserverPattern.Components;
using GofPatterns.Behavioral.ObserverPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.ObserverPattern;

[TestFixture]
internal class PublisherTests : BaseTest
{
    [Test]
    public void AddSubscriber_AddsGivenSubscriber()
    {
        // act - assert
        Assert.DoesNotThrow(() => sutPublisher.AddSubscriber(new PersonJohnDoe(MockConsoleLogger.Object)));
    }

    [TestCase("test")]
    [TestCase("Hello")]
    [TestCase("World")]
    public void NotifySubscriber_NotifiesAddedSubscriber(string givenUpdate)
    {
        // arrange
        var johnDoe = new PersonJohnDoe(MockConsoleLogger.Object);
        var andrewSmith = new PersonAndrewSmith(MockConsoleLogger.Object);

        sutPublisher.AddSubscriber(johnDoe);
        sutPublisher.AddSubscriber(andrewSmith);

        const int expectedLogCount = 2;

        // act
        sutPublisher.NotifySubscribers(givenUpdate);

        // assert
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    [Test]
    public void RemoveSubscribers_RemovesAllSubscribers()
    {
        // arrange
        var johnDoe = new PersonJohnDoe(MockConsoleLogger.Object);
        var andrewSmith = new PersonAndrewSmith(MockConsoleLogger.Object);

        sutPublisher.AddSubscriber(johnDoe);
        sutPublisher.AddSubscriber(andrewSmith);

        const string givenUpdate = "test";
        var expectedLogCount = 2;

        sutPublisher.NotifySubscribers(givenUpdate);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));

        // act
        sutPublisher.RemoveSubscribers();
        sutPublisher.NotifySubscribers(givenUpdate);

        // assert
        expectedLogCount += 0; // Expected log count should not change

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));
    }

    private readonly IPublisher<string> sutPublisher = new Publisher<string>();
}