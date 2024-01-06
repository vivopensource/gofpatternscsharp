namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;

public abstract class ResponsibilityCheck<TInput> : IResponsibilityCheck<TInput>
{
    private readonly Predicate<TInput> predicate;

    protected ResponsibilityCheck(Predicate<TInput> predicate)
    {
        this.predicate = predicate;
    }

    public bool IsResponsible(TInput input)
    {
        var isResponsible = predicate.Invoke(input);
        return isResponsible;
    }
}