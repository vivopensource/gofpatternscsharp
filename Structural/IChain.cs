namespace GofPattern.Structural;

public interface IChain<TOut>
{
    TOut Execute();
    IChain<TOut> AddNextInChain(IChain<TOut> next);
    bool IsResponsible();
}

public interface IChainInput<TOut, TIn>
{
    TOut Execute(TIn i);
    IChainInput<TOut, TIn> AddNextInChain(IChainInput<TOut, TIn> next);
    bool IsResponsible(TIn input);
}