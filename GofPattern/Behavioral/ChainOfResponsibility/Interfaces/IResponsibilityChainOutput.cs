namespace GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

public interface IResponsibilityChainOutput<TNext, out TOut> : IChain<TNext>
    where TNext : IResponsibilityChainOutput<TNext, TOut>
{
    TOut Execute();
}