namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;


public abstract class AbstractResponsibilityChain<TResponsibilityChain, TResponsibility>
    where TResponsibilityChain : AbstractResponsibilityChain<TResponsibilityChain, TResponsibility>
{
    protected AbstractResponsibilityChain(TResponsibility responsibility)
    {
        Name = GetType().Name;
        Responsibility = responsibility;
    }

    internal void SetNext(TResponsibilityChain responsibilityChain)
    {
        if (Next is null)
            Next = responsibilityChain;
        else
            Next.SetNext(responsibilityChain);
    }

    public TResponsibilityChain? Next { get; private set; }

    public string Name { get; internal set; }

    public TResponsibility Responsibility { get; }
}