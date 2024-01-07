using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums.ChainOrchestratorHandleOptions;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex;

public sealed class ResponsibilityChainOrchestrator<TInput> : IResponsibilityChainOrchestrator<TInput>
{
    public ResponsibilityChainOrchestrator() { }

    public ResponsibilityChainOrchestrator(string name)
    {
        Name = name;
    }

    public IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption,
        string? name = null)
    {
        AssembleChain(new ChainLink<IResponsibility<TInput>>(responsibility, handleOption, invokeNextHandlerOption),
            name);

        return this;
    }

    public void Execute(TInput input)
    {
        Execute(input, Chain!);
    }

    private void Execute(TInput input, ChainLink<IResponsibility<TInput>> chainLink)
    {
        var responsibilitySatisfied = IsResponsible(chainLink, input);

        ExecuteHandle(input, responsibilitySatisfied, chainLink);

        InvokeNext(input, responsibilitySatisfied, chainLink);
    }

    private void ExecuteHandle(TInput input, bool responsibilitySatisfied,
        ChainLink<IResponsibility<TInput>> chainLink)
    {
        switch (chainLink.HandleOption)
        {
            case HandleWhenResponsible:
                if (responsibilitySatisfied)
                    chainLink.Responsibility.Handle(input);
                break;

            case HandleAlways:
                chainLink.Responsibility.Handle(input);
                break;
        }
    }

    private void InvokeNext(TInput input, bool responsibilitySatisfied,
        ChainLink<IResponsibility<TInput>> chainLink)
    {
        switch (chainLink.InvokeNextHandlerOption)
        {
            case InvokeNextAlways:
                InvokeNext(input, chainLink);
                return;

            case InvokeNextWhenResponsible:
                if (responsibilitySatisfied)
                    InvokeNext(input, chainLink);
                return;

            case InvokeNextWhenNotResponsible:
                if (!responsibilitySatisfied)
                    InvokeNext(input, chainLink);
                return;

            case InvokeNextNever:
                return;
        }
    }

    private void InvokeNext(TInput input, ChainLink<IResponsibility<TInput>> chainLink)
    {
        if (chainLink.Next is null)
            throw new MissingResponsibilityException();

        Execute(input, chainLink.Next);
    }

    private void AssembleChain(ChainLink<IResponsibility<TInput>> chainLink, string? name = null)
    {
        if (name is not null && !string.Empty.Equals(name.Trim()))
            chainLink.Name = name;

        if (Chain is null)
            Chain = chainLink;
        else
            Chain.SetNext(chainLink);
    }

    private bool IsResponsible(ChainLink<IResponsibility<TInput>> chainLink, TInput input)
    {
        CurrentChain = chainLink;

        var handleWhenResponsible = HandleWhenResponsible == chainLink.HandleOption;

        var responsibility = chainLink.Responsibility as IResponsibilityCheck<TInput>;

        var isResponsible = handleWhenResponsible && responsibility.IsResponsible(input);

        return isResponsible;
    }

    public ChainLink<IResponsibility<TInput>>? Chain { get; private set; }

    public ChainLink<IResponsibility<TInput>>? CurrentChain { get; private set; }

    public string Name { get; set; } = nameof(ResponsibilityChainOrchestrator<TInput>);
}