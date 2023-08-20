namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public abstract class AbstractResponsibilityChain<TResponsibilityChain>
    where TResponsibilityChain : AbstractResponsibilityChain<TResponsibilityChain>
{
    protected AbstractResponsibilityChain(string name)
    {
        Name = name;
    }

    internal void SetNext(TResponsibilityChain responsibilityChain)
    {
        if (Next is null)
            Next = responsibilityChain;
        else
            Next.SetNext(responsibilityChain);
    }

    public TResponsibilityChain? Next { get; private set; }

    public string Name { get; }
}

public abstract class AbstractResponsibilityChain<TResponsibilityChain, TResponsibility>
   : AbstractResponsibilityChain<TResponsibilityChain>
    where TResponsibilityChain : AbstractResponsibilityChain<TResponsibilityChain, TResponsibility>
{
    protected AbstractResponsibilityChain(TResponsibility responsibility, string name) : base(name)
    {
        Responsibility = responsibility;
    }

    public TResponsibility Responsibility { get; }
}