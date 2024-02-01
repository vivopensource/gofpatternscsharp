namespace GofPatterns.Structural.ProxyPattern;

public interface IProxyCachedOutput<TInput, TOutput> : IProxyComponent<TInput, TOutput> where TInput : notnull
{
    IDictionary<TInput, TOutput> Cache { get; }
}