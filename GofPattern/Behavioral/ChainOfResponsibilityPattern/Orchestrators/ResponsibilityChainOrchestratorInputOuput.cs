using GofPattern.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public class ResponsibilityChainOrchestrator<TInput, TOutput> :
    AbstractResponsibilityChainOrchestrator<ResponsibilityChain<TInput, TOutput>>,
    IResponsibilityChainOrchestrator<TInput, TOutput>
{
    public IResponsibilityChainOrchestrator<TInput, TOutput> Append(IResponsibility<TInput, TOutput> responsibility,
        string? name = null)
    {
        var responsibilityChain =
            new ResponsibilityChain<TInput, TOutput>(responsibility, name ?? responsibility.GetType().Name);

        AppendChain(responsibilityChain);

        return this;
    }

    public TOutput Execute(TInput input)
    {
        return Execute(input, Chain!);
    }

    private TOutput Execute(TInput input, ResponsibilityChain<TInput, TOutput> responsibilityChain)
    {
        var responsibilitySatisfied = responsibilityChain.Responsibility.IsResponsible(input);

        if (responsibilitySatisfied)
            return HandleResponsibility(input, responsibilityChain);

        return InvokeNext(input, responsibilityChain);
    }

    private TOutput HandleResponsibility(TInput input, ResponsibilityChain<TInput, TOutput> responsibilityChain)
    {
        ExecuteBeforeHandling(input);

        return responsibilityChain.Responsibility.Handle(input);
    }

    private TOutput InvokeNext(TInput input, ResponsibilityChain<TInput, TOutput> responsibilityChain)
    {
        if (responsibilityChain.Next is null)
            throw new MissingResponsibilityException();

        return Execute(input, responsibilityChain.Next);
    }

    private void ExecuteBeforeHandling(TInput input)
    {
        ActionBeforeHandling?.Invoke();
        ActionInputBeforeHandling?.Invoke(input);
    }

    public Action? ActionBeforeHandling { get; set; }

    public Action<TInput>? ActionInputBeforeHandling { get; set; }
}