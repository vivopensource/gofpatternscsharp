namespace GofPattern.Structural.ProxyPattern;

public class ProxyCachedOutput<TInput, TOutput> :
    IProxyComponent<TInput, TOutput> where TInput : notnull
{
    private readonly IDictionary<TInput, TOutput> cache;
    private readonly IProxyComponent<TInput, TOutput> component;

    protected ProxyCachedOutput(IProxyComponent<TInput, TOutput> component)
    {
        cache = new Dictionary<TInput, TOutput>();
        this.component = component;
    }

    public TOutput Process(TInput input)
    {
        if (!cache.ContainsKey(input))
            cache.Add(input, component.Process(input));

        return cache[input];
    }
}