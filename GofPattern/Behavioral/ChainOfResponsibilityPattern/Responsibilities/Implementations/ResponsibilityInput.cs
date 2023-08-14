using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;

public class Responsibility<TInput> : IResponsibility<TInput>
{
    private readonly Predicate<TInput> predicate;
    private readonly Delegate function;

    public Responsibility(Predicate<TInput> predicate, Delegate function)
    {
        this.predicate = predicate;
        this.function = function;
    }

    public bool IsResponsible(TInput input)
    {
        var isResponsible = predicate.Invoke(input);
        return isResponsible;
    }

    public void Handle(TInput input)
    {
        function.DynamicInvoke(input);
    }
}