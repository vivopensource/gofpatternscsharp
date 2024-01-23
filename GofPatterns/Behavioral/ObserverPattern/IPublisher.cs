namespace GofPatterns.Behavioral.ObserverPattern;

/// <summary>
/// Publisher (or Broadcaster) interface.
/// Publishers are responsible for managing subscribers and notifying them of events.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface IPublisher<TInput>
{
    public void AddSubscriber(ISubscriber<TInput> subscriber);

    public void RemoveSubscribers();

    public void NotifySubscribers(TInput input);
}

/// <summary>
/// Publisher (or Broadcaster) interface.
/// Publishers are responsible for managing subscribers and notifying them of events.
/// Multiple subscribers can be subscribed to a category, and there can be multiple categories.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TCategory"></typeparam>
public interface IPublisher<TInput, in TCategory> where TCategory : notnull
{
    public void AddSubscriber(ISubscriber<TInput> subscriber, TCategory category);

    public void RemoveSubscribers(TCategory category);

    public void NotifySubscribers(TInput input, TCategory category);
}