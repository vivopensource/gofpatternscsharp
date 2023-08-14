namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

public interface IResponsibility<in TInput, out TOutput>
{
    bool IsResponsible(TInput input);

    TOutput Handle(TInput input);
}