using Core.Extensions;
using GofConsoleApp.Examples.Behavioral.ObserverPattern.Components;
using GofPatterns.Behavioral.ObserverPattern;
using GofPatterns.Behavioral.ObserverPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ObserverPattern;

internal class ObserverPatternExample : BaseExample
{
    private readonly IPublisher<string> newsPublisher = new Publisher<string>();

    protected override bool Execute()
    {
        var johnDoe = new PersonJohnDoe(Logger);
        var andrewSmith = new PersonAndrewSmith(Logger);

        newsPublisher.AddSubscriber(johnDoe);
        newsPublisher.AddSubscriber(andrewSmith);

        while (true)
        {
            Logger.LogInfoQuit();

            var newsUpdate = AcceptInputString("news update");

            if (newsUpdate.Trim().ToLower().Equals("quit"))
                break;

            newsPublisher.NotifySubscribers(newsUpdate);
        }

        return true;
    }
}