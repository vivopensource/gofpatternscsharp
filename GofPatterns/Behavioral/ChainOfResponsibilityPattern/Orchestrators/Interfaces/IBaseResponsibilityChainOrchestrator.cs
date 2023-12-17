namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IBaseResponsibilityChainOrchestrator<out TResponsibilityChain>
{
    TResponsibilityChain? Chain { get; }
    TResponsibilityChain? CurrentChain { get; }
}