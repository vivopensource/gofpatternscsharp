using System.Collections.ObjectModel;
using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofPatterns.Structural.ProxyPattern;

/// <summary>
/// Proxy Pattern implementation with cached output.
/// It will cache the output of the component for the next time.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public class ProxyCachedOutput<TInput, TOutput> : IProxyCachedOutput<TInput, TOutput> where TInput : notnull
{
    private readonly IDictionary<TInput, TOutput> cache;
    private readonly IProxyComponent<TInput, TOutput> component;

    public ProxyCachedOutput(IProxyComponent<TInput, TOutput> component)
    {
        cache = new Dictionary<TInput, TOutput>();
        this.component = component;
    }

    public virtual TOutput Process(TInput input)
    {
        if (!cache.ContainsKey(input))
            cache.Add(input, component.Process(input));

        return cache[input];
    }

    public IDictionary<TInput, TOutput> Cache => new ReadOnlyDictionary<TInput, TOutput>(cache);
}