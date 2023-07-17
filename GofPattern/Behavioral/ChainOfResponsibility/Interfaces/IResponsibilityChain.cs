namespace GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

public interface IResponsibilityChain<TNext> : IChain<TNext> where TNext : IResponsibilityChain<TNext>
{
    void Execute();
    void TryExecute();
    void ExecuteMultiple();
}