using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple;

public interface IResponsibilityChainOrchestrator<TInput>
{
    IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility, string? name = null);

    void Execute(TInput input);

    ChainLink<IResponsibility<TInput>>? Chain { get; }

    ChainLink<IResponsibility<TInput>>? CurrentChain { get; }

    string Name { get; }
}

public interface IResponsibilityChainOrchestrator<TInput, TOutput>
{
    IResponsibilityChainOrchestrator<TInput, TOutput> Append(IResponsibility<TInput, TOutput> responsibility,
        string? name = null);

    TOutput Execute(TInput input);

    ChainLink<IResponsibility<TInput, TOutput>>? Chain { get; }

    ChainLink<IResponsibility<TInput, TOutput>>? CurrentChain { get; }

    string Name { get; }
}