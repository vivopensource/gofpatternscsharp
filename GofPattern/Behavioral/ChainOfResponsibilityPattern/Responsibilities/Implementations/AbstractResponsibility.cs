namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;

public abstract class AbstractResponsibility<TInput>
{
    private readonly Predicate<TInput> predicate;

    protected AbstractResponsibility(Predicate<TInput> predicate)
    {
        this.predicate = predicate;
    }

    public bool IsResponsible(TInput input)
    {
        var isResponsible = predicate.Invoke(input);
        return isResponsible;
    }
}