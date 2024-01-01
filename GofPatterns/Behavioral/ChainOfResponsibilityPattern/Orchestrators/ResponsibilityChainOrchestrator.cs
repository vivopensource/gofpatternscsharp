using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public sealed class ResponsibilityChainOrchestrator<TInput> :
    BaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput>, IResponsibility<TInput>>,
    IResponsibilityChainOrchestrator<TInput>
{
    public ResponsibilityChainOrchestrator() { }

    public ResponsibilityChainOrchestrator(string name)
    {
        Name = name;
    }

    public IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility, string? name = null)
    {
        AssembleChain(new ResponsibilityChain<TInput>(responsibility), name);

        return this;
    }

    public void Execute(TInput input)
    {
        Execute(input, Chain!);
    }

    private void Execute(TInput input, ResponsibilityChain<TInput> responsibilityChain)
    {
        var responsibilitySatisfied = IsResponsible(responsibilityChain, input);

        if (responsibilitySatisfied)
            responsibilityChain.Responsibility.Handle(input);
        else
            InvokeNext(input, responsibilityChain);
    }

    private void InvokeNext(TInput input, ResponsibilityChain<TInput> responsibilityChain)
    {
        if (responsibilityChain.Next is null)
            throw new MissingResponsibilityException();

        Execute(input, responsibilityChain.Next);
    }
}

public sealed class ResponsibilityChainOrchestrator<TInput, TOutput> :
    BaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput, TOutput>, IResponsibility<TInput, TOutput>>,
    IResponsibilityChainOrchestrator<TInput, TOutput>
{
    public ResponsibilityChainOrchestrator() { }

    public ResponsibilityChainOrchestrator(string name)
    {
        Name = name;
    }

    public IResponsibilityChainOrchestrator<TInput, TOutput> Append(IResponsibility<TInput, TOutput> responsibility,
        string? name = null)
    {
        AssembleChain(new ResponsibilityChain<TInput, TOutput>(responsibility), name);

        return this;
    }

    public TOutput Execute(TInput input)
    {
        return Execute(input, Chain!);
    }

    private TOutput Execute(TInput input, ResponsibilityChain<TInput, TOutput> responsibilityChain)
    {
        var isResponsible = IsResponsible(responsibilityChain, input);

        var output = isResponsible
            ? responsibilityChain.Responsibility.Handle(input)
            : InvokeNext(input, responsibilityChain);

        return output;
    }

    private TOutput InvokeNext(TInput input, ResponsibilityChain<TInput, TOutput> responsibilityChain)
    {
        if (responsibilityChain.Next is null)
            throw new MissingResponsibilityException();

        return Execute(input, responsibilityChain.Next);
    }
}