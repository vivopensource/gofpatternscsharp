namespace GofPatterns.Structural.ProxyPattern.Interfaces;

public interface IProxyCachedOutput<TInput, TOutput> : IProxyComponent<TInput, TOutput> where TInput : notnull
{
    IDictionary<TInput, TOutput> Cache { get; }
}