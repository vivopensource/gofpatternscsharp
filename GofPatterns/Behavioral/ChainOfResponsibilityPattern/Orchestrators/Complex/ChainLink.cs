using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex;

/// <summary>
/// Chain link part of orchestrator.
/// Contains the responsibility and the next chain.
/// Additional properties for handling and invoking next handler.
/// </summary>
/// <typeparam name="TResponsibility"></typeparam>
public class ChainLink<TResponsibility>
{
    internal ChainLink(TResponsibility responsibility, ChainOrchestratorHandleOptions handleOption,
        ChainOrchestratorInvokeNextOptions invokeNextHandlerOption)
    {
        Name = GetType().Name;
        Responsibility = responsibility;
        HandleOption = handleOption;
        InvokeNextHandlerOption = invokeNextHandlerOption;
    }

    internal void SetNext(ChainLink<TResponsibility> chainLink)
    {
        if (Next is null)
            Next = chainLink;
        else
            Next.SetNext(chainLink);
    }

    public string Name { get; internal set; }

    public TResponsibility Responsibility { get; }

    public ChainLink<TResponsibility>? Next { get; private set; }

    public ChainOrchestratorHandleOptions HandleOption { get; }

    public ChainOrchestratorInvokeNextOptions InvokeNextHandlerOption { get; }
}