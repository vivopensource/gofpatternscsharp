using GofConsoleApp.Examples.Behavioral.ObserverPattern.Components;
using GofPatterns.Behavioral.ObserverPattern;
using GofPatterns.Behavioral.ObserverPattern.Exceptions;
using GofPatterns.Behavioral.ObserverPattern.Interfaces;
using Moq;
using NUnit.Framework;
using static GofConsoleApp.Examples.Behavioral.ObserverPattern.Components.EnumTopic;

namespace GofPatternsTests.Behavioral.ObserverPattern;

[TestFixture]
internal class PublisherTestsWithCategory : BaseTest
{
    [Test]
    public void AddSubscriber_AddsGivenSubscriber()
    {
        // act - assert
        Assert.DoesNotThrow(() => sutPublisher.AddSubscriber(new PersonJohnDoe(MockConsoleLogger.Object), Sports));
    }

    [TestCase("Germany won Fifa world cup.", Sports, 2)]
    [TestCase("Election campaign started by the candidates.", Politics, 1)]
    [TestCase("Heavy snow fall expected in upcoming week.", Weather, 1)]
    [TestCase("Holiday season experience flight booking at all time high.", Holidays, 1)]
    public void NotifySubscriber_NotifiesAddedSubscriber(string givenUpdate, EnumTopic givenCategory,
        int expectedSubscribers)
    {
        // arrange
        var johnDoe = new PersonJohnDoe(MockConsoleLogger.Object);
        var andrewSmith = new PersonAndrewSmith(MockConsoleLogger.Object);

        sutPublisher.AddSubscriber(johnDoe, Sports);
        sutPublisher.AddSubscriber(andrewSmith, Sports);
        sutPublisher.AddSubscriber(johnDoe, Politics);
        sutPublisher.AddSubscriber(andrewSmith, Weather);
        sutPublisher.AddSubscriber(johnDoe, Holidays);

        // act
        sutPublisher.NotifySubscribers(givenUpdate, givenCategory);

        // assert
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedSubscribers));
    }

    [Test]
    public void RemoveSubscribers_RemovesAllSubscribers()
    {
        // arrange
        var johnDoe = new PersonJohnDoe(MockConsoleLogger.Object);
        var andrewSmith = new PersonAndrewSmith(MockConsoleLogger.Object);

        sutPublisher.AddSubscriber(johnDoe, Sports);
        sutPublisher.AddSubscriber(andrewSmith, Sports);
        sutPublisher.AddSubscriber(johnDoe, Politics);
        sutPublisher.AddSubscriber(andrewSmith, Weather);
        sutPublisher.AddSubscriber(johnDoe, Holidays);

        const string givenUpdate = "test";
        const int expectedLogCount = 5;

        sutPublisher.NotifySubscribers(givenUpdate, Sports);
        sutPublisher.NotifySubscribers(givenUpdate, Politics);
        sutPublisher.NotifySubscribers(givenUpdate, Weather);
        sutPublisher.NotifySubscribers(givenUpdate, Holidays);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedLogCount));

        // act
        sutPublisher.RemoveSubscribers(Sports);
        sutPublisher.RemoveSubscribers(Politics);

        // assert
        Assert.Throws<NoSubscriptionFoundException>(() => sutPublisher.NotifySubscribers(givenUpdate, Sports));
        Assert.Throws<NoSubscriptionFoundException>(() => sutPublisher.NotifySubscribers(givenUpdate, Politics));
        Assert.DoesNotThrow(() => sutPublisher.NotifySubscribers(givenUpdate, Weather));
        Assert.DoesNotThrow(() => sutPublisher.NotifySubscribers(givenUpdate, Holidays));
    }

    private readonly IPublisher<string, EnumTopic> sutPublisher = new Publisher<string, EnumTopic>();
}