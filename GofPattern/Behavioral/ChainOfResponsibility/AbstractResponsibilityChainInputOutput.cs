using GofPattern.Behavioral.ChainOfResponsibility.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility;

public abstract class AbstractResponsibilityChainInputOutput<TNext, TIn, TOut> : IResponsibilityChainInputOutput<TNext, TIn, TOut>
    where TNext : IResponsibilityChainInputOutput<TNext, TIn, TOut>
{
    private readonly ChainLink<TNext> chain = new();

    public TOut Execute(TIn input)
    {
        if (IsResponsible(input))
            return Process(input);

        if (chain.Next is null)
            throw new NoResponsibilityException();

        return chain.Next.Execute(input);
    }

    public TNext AddNextInChain(TNext next)
    {
        chain.AddNext(next);
        return (TNext)(object)this;
    }

    protected abstract bool IsResponsible(TIn input);

    protected abstract TOut Process(TIn input);
}