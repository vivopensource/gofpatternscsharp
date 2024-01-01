using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class ResponsibilityChainComplex<TInput> : AbstractResponsibilityChainComplex<ResponsibilityChainComplex<TInput>, IResponsibility<TInput>>
{
    internal ResponsibilityChainComplex(IResponsibility<TInput> responsibility, ChainOrchestratorHandleOptions handleOption,
        ChainOrchestratorInvokeNextOptions invokeNextHandlerOption) : base(responsibility, handleOption,
        invokeNextHandlerOption) { }
}