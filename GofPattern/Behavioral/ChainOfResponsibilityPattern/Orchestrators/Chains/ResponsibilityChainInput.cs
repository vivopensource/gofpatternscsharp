using GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class ResponsibilityChain<TInput>
{
    internal ResponsibilityChain(IResponsibility<TInput> responsibility, ChainOrchestratorHandleOptions handleOption,
        ChainOrchestratorInvokeNextOptions invokeNextHandlerOption, string name)
    {
        Responsibility = responsibility;
        HandleOption = handleOption;
        InvokeNextHandlerOption = invokeNextHandlerOption;
        Name = name;
    }

    internal void SetNext(ResponsibilityChain<TInput> next)
    {
        if (Next is null)
            Next = next;
        else
            Next.SetNext(next);
    }

    public ResponsibilityChain<TInput>? Next { get; private set; }

    public IResponsibility<TInput> Responsibility { get; }

    public ChainOrchestratorHandleOptions HandleOption { get; }

    public ChainOrchestratorInvokeNextOptions InvokeNextHandlerOption { get; }

    public string Name { get; }
}