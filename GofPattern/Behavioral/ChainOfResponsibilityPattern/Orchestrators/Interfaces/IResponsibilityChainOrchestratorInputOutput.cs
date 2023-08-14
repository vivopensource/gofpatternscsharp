using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IResponsibilityChainOrchestrator<in TResponsibility, in TInput, out TOutput>
    where TResponsibility : IResponsibility<TInput, TOutput>
{
    IResponsibilityChainOrchestrator<TResponsibility, TInput, TOutput> Append(TResponsibility nextHandler);

    TOutput Execute(TInput input);
}