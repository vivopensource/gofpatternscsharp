using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IResponsibilityChainOrchestrator<TInput> :
    IBaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput>>,
    IOrchestrationBeforeHandling<TInput>, IOrchestrationAfterHandling<TInput>
{
    IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption,
        string? name = null);

    void Execute(TInput input);
}

public interface IResponsibilityChainOrchestrator<TInput, TOutput> :
    IBaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput, TOutput>>,
    IOrchestrationBeforeHandling<TInput>
{
    IResponsibilityChainOrchestrator<TInput, TOutput> Append(IResponsibility<TInput, TOutput> responsibility,
        string? name = null);

    TOutput Execute(TInput input);
}