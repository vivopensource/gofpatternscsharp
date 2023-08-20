using GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IBaseResponsibilityChainOrchestrator<TResponsibilityChain>
{
    TResponsibilityChain? Chain { get; }
    TResponsibilityChain? CurrentChain { get; }
}

public interface IResponsibilityChainOrchestrator<TInput> :
    IBaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput>>,
    IResponsibilityChainActionBeforeHandling<TInput>,
    IResponsibilityChainActionAfterHandling<TInput>
{
    IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption,
        string? name = null);

    void Execute(TInput input);
}

public interface IResponsibilityChainOrchestrator<TInput, TOutput> :
    IBaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput, TOutput>>, 
    IResponsibilityChainActionBeforeHandling<TInput>
{
    IResponsibilityChainOrchestrator<TInput, TOutput> Append(IResponsibility<TInput, TOutput> responsibility,
        string? name = null);

    TOutput Execute(TInput input);
}