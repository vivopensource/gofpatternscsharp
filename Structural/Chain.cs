namespace GofPattern.Structural;

public abstract class Chain<TOut> : IChain<TOut>
{
    private IChain<TOut>? _nextInChain;

    public TOut Execute()
    {
        return IsResponsible() ? ExecuteResponsibility() : ExecuteNext();
    }

    public IChain<TOut> AddNextInChain(IChain<TOut> next)
    {
        if (_nextInChain is null)
            _nextInChain = next;
        else
            _nextInChain.AddNextInChain(next);

        return this;
    }

    private TOut ExecuteNext()
    {
        if (_nextInChain is null)
            throw new Exception("BROKEN CHAIN!");

        return _nextInChain.Execute();
    }

    public abstract bool IsResponsible();

    protected abstract TOut ExecuteResponsibility();
}

public abstract class Chain<TOut, TIn> : IChainInput<TOut, TIn>
{
    private IChainInput<TOut, TIn>? _nextInChain;

    public TOut Execute(TIn input)
    {
        return IsResponsible(input) ? ExecuteResponsibility(input) : ExecuteNext(input);
    }

    public IChainInput<TOut, TIn> AddNextInChain(IChainInput<TOut, TIn> next)
    {
        if (_nextInChain is null)
            _nextInChain = next;
        else
            _nextInChain.AddNextInChain(next);

        return this;
    }

    private TOut ExecuteNext(TIn input)
    {
        if (_nextInChain is null)
            throw new Exception("BROKEN CHAIN!");

        return _nextInChain.Execute(input);
    }

    public abstract bool IsResponsible(TIn input);

    protected abstract TOut ExecuteResponsibility(TIn input);
}