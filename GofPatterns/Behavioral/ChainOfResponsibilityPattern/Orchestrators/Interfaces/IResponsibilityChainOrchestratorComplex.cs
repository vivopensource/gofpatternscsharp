using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IResponsibilityChainOrchestratorComplex<TInput> :
    IBaseResponsibilityChainOrchestrator<ResponsibilityChainComplex<TInput>>
{
    IResponsibilityChainOrchestratorComplex<TInput> Append(IResponsibility<TInput> responsibility,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption,
        string? name = null);

    void Execute(TInput input);
}