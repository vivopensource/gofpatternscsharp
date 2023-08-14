using GofPattern.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public class
    ResponsibilityChainOrchestrator<TResponsibility, TInput, TOutput> : IResponsibilityChainOrchestrator<TResponsibility
        , TInput, TOutput> where TResponsibility : IResponsibility<TInput, TOutput>
{
    public IResponsibilityChainOrchestrator<TResponsibility, TInput, TOutput> Append(TResponsibility nextHandler)
    {
        var responsibilityChain =
            new ResponsibilityChain<TResponsibility, TInput, TOutput>(nextHandler);

        if (root is null)
            root = responsibilityChain;
        else
            root.SetNext(responsibilityChain);

        return this;
    }

    public TOutput Execute(TInput input)
    {
        return Execute(input, root!);
    }

    private TOutput Execute(TInput input, ResponsibilityChain<TResponsibility, TInput, TOutput> responsibilityChain)
    {
        var responsibilitySatisfied = responsibilityChain.Responsibility.IsResponsible(input);

        if (responsibilitySatisfied)
            return responsibilityChain.Responsibility.Handle(input);

        return InvokeNext(input, responsibilityChain);
    }

    private TOutput InvokeNext(TInput input, ResponsibilityChain<TResponsibility, TInput, TOutput> responsibilityChain)
    {
        if (responsibilityChain.Next is null)
            throw new MissingResponsibilityException();

        return Execute(input, responsibilityChain.Next);
    }

    private ResponsibilityChain<TResponsibility, TInput, TOutput>? root;
}