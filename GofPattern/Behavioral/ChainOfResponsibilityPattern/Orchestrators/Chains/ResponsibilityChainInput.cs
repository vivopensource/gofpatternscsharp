using GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class ResponsibilityChain<TResponsibility, TInput>
{
    public ResponsibilityChain(TResponsibility responsibility, ChainOrchestratorHandleOptions handleOption,
        ChainOrchestratorInvokeNextOptions invokeNextHandlerOption)
    {
        Responsibility = responsibility;
        HandleOption = handleOption;
        InvokeNextHandlerOption = invokeNextHandlerOption;
    }

    internal void SetNext(ResponsibilityChain<TResponsibility, TInput> next)
    {
        if (Next is null)
            Next = next;
        else
            Next.SetNext(next);
    }

    internal ResponsibilityChain<TResponsibility, TInput>? Next { get; private set; }

    public TResponsibility Responsibility { get; }

    public ChainOrchestratorHandleOptions HandleOption { get; }

    public ChainOrchestratorInvokeNextOptions InvokeNextHandlerOption { get; }
}