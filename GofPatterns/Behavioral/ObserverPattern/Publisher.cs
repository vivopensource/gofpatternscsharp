using GofPatterns.Behavioral.ObserverPattern.Exceptions;
using GofPatterns.Behavioral.ObserverPattern.Interfaces;

namespace GofPatterns.Behavioral.ObserverPattern;

/// <summary>
/// Implementation of the Publisher (or Broadcaster) interface.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public class Publisher<TInput> : IPublisher<TInput>
{
    private readonly List<ISubscriber<TInput>> subscribers = new();

    public void AddSubscriber(ISubscriber<TInput> subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void RemoveSubscribers()
    {
        subscribers.Clear();
    }

    public void NotifySubscribers(TInput input)
    {
        subscribers.ForEach(x => x.Update(input));
    }
}

/// <summary>
/// Implementation of the Publisher (or Broadcaster) interface.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TCategory"></typeparam>
public class Publisher<TInput, TCategory> : IPublisher<TInput, TCategory> where TCategory : notnull
{
    private readonly Dictionary<TCategory, IPublisher<TInput>> publishers = new();

    public void AddSubscriber(ISubscriber<TInput> subscriber, TCategory category)
    {
        IPublisher<TInput> publisher;

        if (publishers.TryGetValue(category, out var outputPublisher))
            publisher = outputPublisher;
        else
            publishers[category] = publisher = new Publisher<TInput>();

        publisher.AddSubscriber(subscriber);
    }

    public void RemoveSubscribers(TCategory category)
    {
        VerifySubscription(category);
        publishers.Remove(category);
    }

    public void NotifySubscribers(TInput input, TCategory category)
    {
        VerifySubscription(category);
        publishers[category].NotifySubscribers(input);
    }

    private void VerifySubscription(TCategory type)
    {
        if (!publishers.ContainsKey(type))
            throw new NoSubscriptionFoundException($"No subscription found for category: {type}");
    }
}