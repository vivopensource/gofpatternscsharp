using Core.Extensions;
using GofConsoleApp.Examples.Behavioral.ObserverPattern.Components;
using GofPatterns.Behavioral.ObserverPattern;

namespace GofConsoleApp.Examples.Behavioral.ObserverPattern;

internal class ObserverPatternExampleWithCategory : BaseExample
{
    private readonly IPublisher<string, EnumTopic> newsPublisher = new Publisher<string, EnumTopic>();

    protected override bool Execute()
    {
        var johnDoe = new PersonJohnDoe(Logger);
        var andrewSmith = new PersonAndrewSmith(Logger);

        newsPublisher.AddSubscriber(johnDoe, EnumTopic.Sports);
        newsPublisher.AddSubscriber(andrewSmith, EnumTopic.Sports);
        newsPublisher.AddSubscriber(johnDoe, EnumTopic.Politics);
        newsPublisher.AddSubscriber(andrewSmith, EnumTopic.Weather);
        newsPublisher.AddSubscriber(johnDoe, EnumTopic.Holidays);

        do
        {
            Logger.LogInfoQuit();

            var topic = AcceptInputEnum(EnumTopic.Invalid, nameof(EnumTopic), EnumTopic.Invalid);

            if (IsInvalidOrQuit(topic, EnumTopic.Invalid, EnumTopic.Quit, out _))
                return true;

            var newsUpdate = AcceptInputString($"{topic} news update");

            newsPublisher.NotifySubscribers(newsUpdate, topic);

        } while (true);
    }
}
