using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Exceptions;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorInvokeNextOptions;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public sealed class ResponsibilityChainOrchestratorComplex<TInput> :
    BaseResponsibilityChainOrchestratorComplex<ResponsibilityChainComplex<TInput>, IResponsibility<TInput>>,
    IResponsibilityChainOrchestratorComplex<TInput>
{
    public ResponsibilityChainOrchestratorComplex() {}

    public ResponsibilityChainOrchestratorComplex(string name)
    {
        Name = name;
    }

    public IResponsibilityChainOrchestratorComplex<TInput> Append(IResponsibility<TInput> responsibility,
        ChainOrchestratorHandleOptions handleOption, ChainOrchestratorInvokeNextOptions invokeNextHandlerOption,
        string? name = null)
    {
        AssembleChain(new ResponsibilityChainComplex<TInput>(responsibility, handleOption, invokeNextHandlerOption), name);

        return this;
    }

    public void Execute(TInput input)
    {
        Execute(input, Chain!);
    }

    private void Execute(TInput input, ResponsibilityChainComplex<TInput> responsibilityChain)
    {
        var responsibilitySatisfied = IsResponsible(responsibilityChain, input);

        ExecuteHandle(input, responsibilitySatisfied, responsibilityChain);

        InvokeNext(input, responsibilitySatisfied, responsibilityChain);
    }

    private void ExecuteHandle(TInput input, bool responsibilitySatisfied,
        ResponsibilityChainComplex<TInput> responsibilityChain)
    {
        switch (responsibilityChain.HandleOption)
        {
            case HandleWhenResponsible:
                if (responsibilitySatisfied)
                    responsibilityChain.Responsibility.Handle(input);
                break;

            case HandleAlways:
                responsibilityChain.Responsibility.Handle(input);
                break;
        }
    }

    private void InvokeNext(TInput input, bool responsibilitySatisfied,
        ResponsibilityChainComplex<TInput> responsibilityChain)
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

    private void InvokeNext(TInput input, ResponsibilityChainComplex<TInput> responsibilityChain)
    {
        if (responsibilityChain.Next is null)
            throw new MissingResponsibilityException();

        Execute(input, responsibilityChain.Next);
    }
}