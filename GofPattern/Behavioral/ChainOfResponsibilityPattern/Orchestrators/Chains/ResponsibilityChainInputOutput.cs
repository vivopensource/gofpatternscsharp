namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class ResponsibilityChain<TResponsibility, TInput, TOutput>
{
    public ResponsibilityChain(TResponsibility responsibility)
    {
        Responsibility = responsibility;
    }

    internal void SetNext(ResponsibilityChain<TResponsibility, TInput, TOutput> next)
    {
        if (Next is null)
            Next = next;
        else
            Next.SetNext(next);
    }

    internal ResponsibilityChain<TResponsibility, TInput, TOutput>? Next { get; private set; }

    public TResponsibility Responsibility { get; }
}