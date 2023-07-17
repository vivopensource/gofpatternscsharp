namespace GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

public interface IResponsibilityChainInputOutput<TNext, in TIn, out TOut> : IChain<TNext>
    where TNext : IResponsibilityChainInputOutput<TNext, TIn, TOut>
{
    TOut Execute(TIn input);
}