using GofPattern.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public class ResponsibilityChainOrchestrator<TInput, TOutput> :
    BaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput, TOutput>, IResponsibility<TInput, TOutput>>,
    IResponsibilityChainOrchestrator<TInput, TOutput>
{
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
            ? HandleResponsibility(input, responsibilityChain)
            : InvokeNext(input, responsibilityChain);

        return output;
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
        ExecuteBefore?.Invoke();
        ExecuteBeforeWithInput?.Invoke(input);
    }

    public Action? ExecuteBefore { get; set; }

    public Action<TInput>? ExecuteBeforeWithInput { get; set; }
}