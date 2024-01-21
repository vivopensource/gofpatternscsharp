namespace GofPatterns.Behavioral.ObserverPattern.Exceptions;

public class NoSubscriptionFoundException : Exception
{
    public NoSubscriptionFoundException(string message) : base(message) { }
}