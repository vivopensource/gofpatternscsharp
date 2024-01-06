namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

public interface IResponsibility<in TInput> : IResponsibilityCheck<TInput>
{
    void Handle(TInput input);
}

public interface IResponsibility<in TInput, out TOutput> : IResponsibilityCheck<TInput>
{
    TOutput Handle(TInput input);
}