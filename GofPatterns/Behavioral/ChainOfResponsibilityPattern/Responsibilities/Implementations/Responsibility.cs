using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;

public class Responsibility<TInput> : BaseResponsibility<TInput>, IResponsibility<TInput>
{
    private readonly Delegate function;

    public Responsibility(Predicate<TInput> predicate, Delegate function) : base(predicate)
    {
        this.function = function;
    }

    public void Handle(TInput input)
    {
        function.DynamicInvoke(input);
    }
}

public class Responsibility<TInput, TOutput> : BaseResponsibility<TInput>, IResponsibility<TInput, TOutput>
{
    private readonly Func<TInput, TOutput> function;

    public Responsibility(Predicate<TInput> predicate, Func<TInput, TOutput> function) : base(predicate)
    {
        this.function = function;
    }

    public TOutput Handle(TInput input)
    {
        return function.Invoke(input);
    }
}