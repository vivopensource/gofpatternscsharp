using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IResponsibilityChainOrchestrator<TInput, TOutput> : IResponsibilityChainActionBeforeHandling<TInput>
{
    IResponsibilityChainOrchestrator<TInput, TOutput> Append(IResponsibility<TInput, TOutput> responsibility,
        string? name = null);

    TOutput Execute(TInput input);

    ResponsibilityChain<TInput, TOutput>? Chain { get; }
}