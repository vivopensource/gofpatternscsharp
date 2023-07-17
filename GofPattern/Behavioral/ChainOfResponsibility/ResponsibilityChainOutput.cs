using GofPattern.Behavioral.ChainOfResponsibility.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility;

public abstract class AbstractResponsibilityChain<TNext> : IResponsibilityChain<TNext>
    where TNext : IResponsibilityChain<TNext>
{
    private readonly ChainLink<TNext> chain = new();

    public void Execute()
    {
        if (IsResponsible())
        {
            Process();
            return;
        }

        if (chain.Next is null)
            throw new NoResponsibilityException();

        chain.Next.Execute();
    }

    public void TryExecute()
    {
        try
        {
            Execute();
        }
        catch (NoResponsibilityException)
        {
            // ignored
        }
    }

    public void ExecuteMultiple()
    {
        if (IsResponsible())
            Process();

        if (chain.Next is not null)
            chain.Next.ExecuteMultiple();
    }

    public TNext AddNextInChain(TNext next)
    {
        chain.AddNext(next);
        return (TNext)(object)this;
    }

    protected abstract bool IsResponsible();
    protected abstract void Process();
}

public abstract class ResponsibilityChainOutput<TNext, TOut> : IResponsibilityChainOutput<TNext, TOut>
    where TNext : IResponsibilityChainOutput<TNext, TOut>
{
    private readonly ChainLink<TNext> chain = new();

    public TOut Execute()
    {
        if (IsResponsible())
            return Process();

        if (chain.Next is null)
            throw new NoResponsibilityException();

        return chain.Next.Execute();
    }

    public TNext AddNextInChain(TNext next)
    {
        chain.AddNext(next);
        return (TNext)(object)this;
    }

    protected abstract bool IsResponsible();
    protected abstract TOut Process();
}
