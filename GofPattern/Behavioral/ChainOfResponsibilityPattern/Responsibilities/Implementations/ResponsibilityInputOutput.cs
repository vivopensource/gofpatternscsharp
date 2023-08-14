using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Implementations;

public class Responsibility<TInput, TOutput> : IResponsibility<TInput, TOutput>
{
    private readonly Predicate<TInput> predicate;
    private readonly Func<TInput, TOutput>? function;
    private readonly TOutput? output;

    public Responsibility(Predicate<TInput> predicate,  Func<TInput, TOutput> function)
    {
        this.predicate = predicate;
        this.function = function;
    }

    public Responsibility(Predicate<TInput> predicate, TOutput output)
    {
        this.predicate = predicate;
        this.output = output;
    }

    public bool IsResponsible(TInput input)
    {
        return predicate.Invoke(input);
    }

    public TOutput Handle(TInput input)
    {
        if (function != null)
            return function.Invoke(input);

        return output!;
    }
}