using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class ResponsibilityChain<TInput, TOutput>
{
    public ResponsibilityChain(IResponsibility<TInput, TOutput> responsibility, string name)
    {
        Responsibility = responsibility;
        Name = name;
    }

    internal void SetNext(ResponsibilityChain<TInput, TOutput> responsibilityChain)
    {
        if (Next is null)
            Next = responsibilityChain;
        else
            Next.SetNext(responsibilityChain);
    }

    public ResponsibilityChain<TInput, TOutput>? Next { get; private set; }

    public IResponsibility<TInput, TOutput> Responsibility { get; }

    public string Name { get; }
}