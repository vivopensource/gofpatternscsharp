using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple;

/// <summary>
/// Chain of Responsibility Orchestrator.
/// Responsible for assembling the responsibilities and executing the chain.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public sealed class ResponsibilityChainOrchestrator<TInput> : IResponsibilityChainOrchestrator<TInput>
{
    public ResponsibilityChainOrchestrator() { }

    public ResponsibilityChainOrchestrator(string name)
    {
        Name = name;
    }

    public IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility, string? name = null)
    {
        AssembleChain(new ChainLink<IResponsibility<TInput>>(responsibility), name);

        return this;
    }

    public void Execute(TInput input)
    {
        Execute(input, Chain!);
    }

    private void Execute(TInput input, ChainLink<IResponsibility<TInput>> chainLink)
    {
        var responsibilitySatisfied = IsResponsible(chainLink, input);

        if (responsibilitySatisfied)
            chainLink.Responsibility.Handle(input);
        else
            InvokeNext(input, chainLink);
    }

    private void InvokeNext(TInput input, ChainLink<IResponsibility<TInput>> chainLink)
    {
        if (chainLink.Next is null)
            throw new MissingResponsibilityException();

        Execute(input, chainLink.Next);
    }

    private void AssembleChain(ChainLink<IResponsibility<TInput>> chainLink, string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
            chainLink.Name = name;

        if (Chain is null)
            Chain = chainLink;
        else
            Chain.SetNext(chainLink);
    }

    private bool IsResponsible(ChainLink<IResponsibility<TInput>> chainLink, TInput input)
    {
        CurrentChain = chainLink;

        var responsibility = chainLink.Responsibility as IResponsibilityCheck<TInput>;

        var isResponsible = responsibility.IsResponsible(input);

        return isResponsible;
    }

    public ChainLink<IResponsibility<TInput>>? Chain { get; private set; }

    public ChainLink<IResponsibility<TInput>>? CurrentChain { get; private set; }

    public string Name { get; set; } = nameof(ResponsibilityChainOrchestrator<TInput>);
}

/// <summary>
/// Chain of Responsibility Orchestrator.
/// Responsible for assembling the responsibilities and executing the chain returning an output.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public sealed class ResponsibilityChainOrchestrator<TInput, TOutput> : IResponsibilityChainOrchestrator<TInput, TOutput>
{
    public ResponsibilityChainOrchestrator() { }

    public ResponsibilityChainOrchestrator(string name)
    {
        Name = name;
    }

    public IResponsibilityChainOrchestrator<TInput, TOutput> Append(IResponsibility<TInput, TOutput> responsibility,
        string? name = null)
    {
        AssembleChain(new ChainLink<IResponsibility<TInput, TOutput>>(responsibility), name);

        return this;
    }

    public TOutput Execute(TInput input)
    {
        return Execute(input, Chain!);
    }

    private TOutput Execute(TInput input, ChainLink<IResponsibility<TInput, TOutput>> chainLink)
    {
        var isResponsible = IsResponsible(chainLink, input);

        var output = isResponsible
            ? chainLink.Responsibility.Handle(input)
            : InvokeNext(input, chainLink);

        return output;
    }

    private TOutput InvokeNext(TInput input, ChainLink<IResponsibility<TInput, TOutput>> chainLink)
    {
        if (chainLink.Next is null)
            throw new MissingResponsibilityException();

        return Execute(input, chainLink.Next);
    }

    private void AssembleChain(ChainLink<IResponsibility<TInput, TOutput>> chainLink, string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
            chainLink.Name = name;

        if (Chain is null)
            Chain = chainLink;
        else
            Chain.SetNext(chainLink);
    }

    private bool IsResponsible(ChainLink<IResponsibility<TInput, TOutput>>chainLink, TInput input)
    {
        CurrentChain = chainLink;

        var responsibility = chainLink.Responsibility as IResponsibilityCheck<TInput>;

        var isResponsible = responsibility.IsResponsible(input);

        return isResponsible;
    }

    public ChainLink<IResponsibility<TInput, TOutput>>? Chain { get; private set; }

    public ChainLink<IResponsibility<TInput, TOutput>>? CurrentChain { get; private set; }

    public string Name { get; set; } = nameof(ResponsibilityChainOrchestrator<TInput, TOutput>);
}