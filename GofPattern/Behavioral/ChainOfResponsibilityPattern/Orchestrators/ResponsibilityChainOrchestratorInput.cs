using GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public class
    ResponsibilityChainOrchestrator<TResponsibility, TInput> : IResponsibilityChainOrchestrator<TResponsibility, TInput>
    where TResponsibility : IResponsibility<TInput>
{
    public IResponsibilityChainOrchestrator<TResponsibility, TInput> Append(TResponsibility nextHandler,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption)
    {
        var responsibilityChain =
            new ResponsibilityChain<TResponsibility, TInput>(nextHandler, handleOption, invokeNextHandlerOption);

        if (root is null)
            root = responsibilityChain;
        else
            root.SetNext(responsibilityChain);

        return this;
    }

    public void Execute(TInput input)
    {
        Execute(input, root!);
    }

    private void Execute(TInput input, ResponsibilityChain<TResponsibility, TInput> responsibilityChain)
    {
        var isResponsible = HandleWhenResponsible == responsibilityChain.HandleOption;

        var responsibilitySatisfied = isResponsible && responsibilityChain.Responsibility.IsResponsible(input);

        ExecuteHandle(input, responsibilitySatisfied, responsibilityChain);

        InvokeNext(input, responsibilitySatisfied, responsibilityChain);
    }

    private void ExecuteHandle(TInput input, bool responsibilitySatisfied,
        ResponsibilityChain<TResponsibility, TInput> responsibilityChain)
    {
        switch (responsibilityChain.HandleOption)
        {
            case HandleWhenResponsible:
                if (responsibilitySatisfied)
                    HandleResponsibility(input, responsibilityChain);
                break;
            case HandleAlways:
                HandleResponsibility(input, responsibilityChain);
                break;
        }
    }

    private void HandleResponsibility(TInput input, ResponsibilityChain<TResponsibility, TInput> responsibilityChain)
    {
        ExecuteBeforeHandling(input, responsibilityChain);

        responsibilityChain.Responsibility.Handle(input);

        ExecuteAfterHandling(input, responsibilityChain);
    }

    private void InvokeNext(TInput input, bool responsibilitySatisfied,
        ResponsibilityChain<TResponsibility, TInput> responsibilityChain)
    {
        switch (responsibilityChain.InvokeNextHandlerOption)
        {
            case InvokeNextAlways:
                InvokeNext(input, responsibilityChain);
                return;
            case InvokeNextWhenResponsible:
                if (responsibilitySatisfied)
                    InvokeNext(input, responsibilityChain);
                return;
            case InvokeNextWhenNotResponsible:
                if (!responsibilitySatisfied)
                    InvokeNext(input, responsibilityChain);
                return;
            case InvokeNextNever:
                return;
        }
    }

    private void InvokeNext(TInput input, ResponsibilityChain<TResponsibility, TInput> responsibilityChain)
    {
        if (responsibilityChain.Next is null)
            throw new MissingResponsibilityException();

        Execute(input, responsibilityChain.Next);
    }

    private ResponsibilityChain<TResponsibility, TInput>? root;

    public virtual void ExecuteBeforeHandling(TInput input,
        ResponsibilityChain<TResponsibility, TInput> responsibilityChain)
    {
        // can be implemented by child
    }

    public virtual void ExecuteAfterHandling(TInput input,
        ResponsibilityChain<TResponsibility, TInput> responsibilityChain)
    {
        // can be implemented by child
    }
}