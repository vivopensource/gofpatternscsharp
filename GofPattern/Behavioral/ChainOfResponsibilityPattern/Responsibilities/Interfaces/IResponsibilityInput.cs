namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

public interface IResponsibility<in TInput>
{
    bool IsResponsible(TInput input);

    void Handle(TInput input);
}