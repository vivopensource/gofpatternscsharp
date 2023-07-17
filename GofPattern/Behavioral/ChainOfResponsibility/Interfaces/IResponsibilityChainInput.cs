namespace GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

public interface IResponsibilityChainInput<TNext, in TIn> : IChain<TNext> where TNext : IResponsibilityChainInput<TNext, TIn>
{
    void Execute(TIn input);
    void TryExecute(TIn input);
    void ExecuteMultiple(TIn input);
    void TryExecuteMultiple(TIn input);
}