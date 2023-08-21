using GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public class ResponsibilityChainOrchestrator<TInput> :
    BaseResponsibilityChainOrchestrator<ResponsibilityChain<TInput>, IResponsibility<TInput>>,
    IResponsibilityChainOrchestrator<TInput>
{
    public IResponsibilityChainOrchestrator<TInput> Append(IResponsibility<TInput> responsibility,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption,
        string? name = null)
    {
        AssembleChain(new ResponsibilityChain<TInput>(responsibility, handleOption, invokeNextHandlerOption), name);

        return this;
    }

    public void Execute(TInput input)
    {
        Execute(input, Chain!);
    }

    private void Execute(TInput input, ResponsibilityChain<TInput> responsibilityChain)
    {
        var responsibilitySatisfied = IsResponsible(responsibilityChain, input);

        ExecuteHandle(input, responsibilitySatisfied, responsibilityChain);

        InvokeNext(input, responsibilitySatisfied, responsibilityChain);
    }

    private void ExecuteHandle(TInput input, bool responsibilitySatisfied,
        ResponsibilityChain<TInput> responsibilityChain)
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

    private void HandleResponsibility(TInput input, ResponsibilityChain<TInput> responsibilityChain)
    {
        ExecuteBeforeHandling(input);

        responsibilityChain.Responsibility.Handle(input);

        ExecuteAfterHandling(input);
    }

    private void InvokeNext(TInput input, bool responsibilitySatisfied,
        ResponsibilityChain<TInput> responsibilityChain)
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

    private void InvokeNext(TInput input, ResponsibilityChain<TInput> responsibilityChain)
    {
        if (responsibilityChain.Next is null)
            throw new MissingResponsibilityException();

        Execute(input, responsibilityChain.Next);
    }

    private void ExecuteBeforeHandling(TInput input)
    {
        ExecuteBefore?.Invoke();
        ExecuteBeforeWithInput?.Invoke(input);
    }

    private void ExecuteAfterHandling(TInput input)
    {
        ExecuteAfterWithInput?.Invoke(input);
        ExecuteAfter?.Invoke();
    }

    public Action? ExecuteBefore { get; set; }

    public Action<TInput>? ExecuteBeforeWithInput { get; set; }

    public Action? ExecuteAfter { get; set; }

    public Action<TInput>? ExecuteAfterWithInput { get; set; }
}