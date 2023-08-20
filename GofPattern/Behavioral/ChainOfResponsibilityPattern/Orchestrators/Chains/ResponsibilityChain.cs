using GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class
    ResponsibilityChain<TInput> : AbstractResponsibilityChain<ResponsibilityChain<TInput>, IResponsibility<TInput>>
{
    internal ResponsibilityChain(IResponsibility<TInput> responsibility, ChainOrchestratorHandleOptions handleOption,
        ChainOrchestratorInvokeNextOptions invokeNextHandlerOption) : base(responsibility)
    {
        HandleOption = handleOption;
        InvokeNextHandlerOption = invokeNextHandlerOption;
    }

    public ChainOrchestratorHandleOptions HandleOption { get; }

    public ChainOrchestratorInvokeNextOptions InvokeNextHandlerOption { get; }
}

public class ResponsibilityChain<TInput, TOutput> : AbstractResponsibilityChain<ResponsibilityChain<TInput, TOutput>,
    IResponsibility<TInput, TOutput>>
{
    public ResponsibilityChain(IResponsibility<TInput, TOutput> responsibility) : base(responsibility) { }
}