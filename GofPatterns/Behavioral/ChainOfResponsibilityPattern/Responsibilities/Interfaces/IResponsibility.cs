namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

public interface IResponsibility<in TInput> : IBaseResponsibility<TInput>
{
    void Handle(TInput input);
}

public interface IResponsibility<in TInput, out TOutput> : IBaseResponsibility<TInput>
{
    TOutput Handle(TInput input);
}