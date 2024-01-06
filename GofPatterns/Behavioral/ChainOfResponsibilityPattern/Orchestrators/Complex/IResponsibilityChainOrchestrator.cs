using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex;

public interface IResponsibilityChainOrchestrator<TInput>
{
    IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption,
        string? name = null);

    void Execute(TInput input);

    ChainLink<IResponsibility<TInput>>? Chain { get; }

    ChainLink<IResponsibility<TInput>>? CurrentChain { get; }

    string Name { get; }
}