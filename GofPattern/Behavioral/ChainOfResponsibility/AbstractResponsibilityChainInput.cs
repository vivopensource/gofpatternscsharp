using GofPattern.Behavioral.ChainOfResponsibility.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility;

public abstract class AbstractResponsibilityChainInput<TNext, TIn> : IResponsibilityChainInput<TNext, TIn>
    where TNext : IResponsibilityChainInput<TNext, TIn>
{
    private readonly ChainLink<TNext> chain = new();

    public void Execute(TIn input)
    {
        if (IsResponsible(input))
        {
            Process(input);
            return;
        }

        if (chain.Next is null)
            throw new NoResponsibilityException();

        chain.Next.Execute(input);
    }

    public void TryExecute(TIn input)
    {
        try
        {
            Execute(input);
        }
        catch (NoResponsibilityException)
        {
            // ignored
        }
    }

    private void ExecuteMultiple(TIn input, bool matchedResponsibility)
    {
        if (IsResponsible(input))
        {
            Process(input);
            matchedResponsibility = true;
        }

        if (chain.Next is not null)
        {
            var next = chain.Next as AbstractResponsibilityChainInput<TNext, TIn>;
            next!.ExecuteMultiple(input, matchedResponsibility);
        }
        else if (!matchedResponsibility)
            throw new NoResponsibilityException();
    }

    public void ExecuteMultiple(TIn input) => ExecuteMultiple(input, false);

    public void TryExecuteMultiple(TIn input)
    {
        try
        {
            ExecuteMultiple(input);
        }
        catch (NoResponsibilityException)
        {
            // ignored
        }
    }

    public TNext AddNextInChain(TNext next)
    {
        chain.AddNext(next);
        return (TNext)(object)this;
    }

    protected abstract bool IsResponsible(TIn input);

    protected abstract void Process(TIn input);
}