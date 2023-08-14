using GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IResponsibilityChainOrchestrator<TResponsibility, TInput>
    where TResponsibility : IResponsibility<TInput>
{
    IResponsibilityChainOrchestrator<TResponsibility, TInput> Append(TResponsibility nextHandler,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption);

    void Execute(TInput input);

    void ExecuteBeforeHandling(TInput input, ResponsibilityChain<TResponsibility, TInput> responsibilityChain);

    void ExecuteAfterHandling(TInput input, ResponsibilityChain<TResponsibility, TInput> responsibilityChain);
}