using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public abstract class AbstractResponsibilityChain<TResponsibilityChain, TResponsibility>
    where TResponsibilityChain : AbstractResponsibilityChain<TResponsibilityChain, TResponsibility>
{
    protected AbstractResponsibilityChain(TResponsibility responsibility, ChainOrchestratorHandleOptions handleOption,
        ChainOrchestratorInvokeNextOptions invokeNextHandlerOption)
    {
        Name = GetType().Name;
        Responsibility = responsibility;
        HandleOption = handleOption;
        InvokeNextHandlerOption = invokeNextHandlerOption;
    }

    internal void SetNext(TResponsibilityChain responsibilityChain)
    {
        if (Next is null)
            Next = responsibilityChain;
        else
            Next.SetNext(responsibilityChain);
    }

    public string Name { get; internal set; }

    public TResponsibility Responsibility { get; }

    public ChainOrchestratorHandleOptions HandleOption { get; }

    public ChainOrchestratorInvokeNextOptions InvokeNextHandlerOption { get; }

    public TResponsibilityChain? Next { get; private set; }
}