using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class ResponsibilityChain<TInput> : AbstractResponsibilityChain<ResponsibilityChain<TInput>, IResponsibility<TInput>>
{
    internal ResponsibilityChain(IResponsibility<TInput> responsibility, ChainOrchestratorHandleOptions handleOption,
        ChainOrchestratorInvokeNextOptions invokeNextHandlerOption) : base(responsibility, handleOption,
        invokeNextHandlerOption) { }
}

public class ResponsibilityChain<TInput, TOutput> : AbstractResponsibilityChain<ResponsibilityChain<TInput, TOutput>,
    IResponsibility<TInput, TOutput>>
{
    public ResponsibilityChain(IResponsibility<TInput, TOutput> responsibility) : base(responsibility,
        ChainOrchestratorHandleOptions.HandleWhenResponsible,
        ChainOrchestratorInvokeNextOptions.InvokeNextWhenNotResponsible) { }
}