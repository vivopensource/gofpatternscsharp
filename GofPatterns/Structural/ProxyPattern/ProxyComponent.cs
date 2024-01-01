using GofPatterns.Core;
using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofPatterns.Structural.ProxyPattern;

public class ProxyComponent<TInput> : IProxyComponent<TInput>
{
    private readonly Handler<TInput> handler;

    public ProxyComponent(Delegate function)
    {
        handler = new Handler<TInput>(function);
    }

    public void Process(TInput input)
    {
        handler.Handle(input);
    }
}

public class ProxyComponent<TInput, TOutput> : IProxyComponent<TInput, TOutput>
{
    private readonly Handler<TInput, TOutput> handler;

    public ProxyComponent(Func<TInput, TOutput> function)
    {
        handler = new Handler<TInput, TOutput>(function);
    }

    public TOutput Process(TInput input)
    {
        return handler.Handle(input);
    }
}