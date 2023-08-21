using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;

public abstract class BaseResponsibility<TInput> : IBaseResponsibility<TInput>
{
    private readonly Predicate<TInput> predicate;

    protected BaseResponsibility(Predicate<TInput> predicate)
    {
        this.predicate = predicate;
    }

    public bool IsResponsible(TInput input)
    {
        var isResponsible = predicate.Invoke(input);
        return isResponsible;
    }
}