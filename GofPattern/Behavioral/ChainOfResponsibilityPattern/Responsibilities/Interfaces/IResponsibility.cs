namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

public interface IResponsibility<in TInput>
{
    bool IsResponsible(TInput input);

    void Handle(TInput input);
}

public interface IResponsibility<in TInput, out TOutput>
{
    bool IsResponsible(TInput input);

    TOutput Handle(TInput input);
}