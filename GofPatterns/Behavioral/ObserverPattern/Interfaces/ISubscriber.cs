namespace GofPatterns.Behavioral.ObserverPattern.Interfaces;

/// <summary>
/// Subscriber (or Listener) interface.
/// Subscribers are interested in certain events and implement the Update method to handle them.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface ISubscriber<in TInput>
{
    void Update(TInput input);
}