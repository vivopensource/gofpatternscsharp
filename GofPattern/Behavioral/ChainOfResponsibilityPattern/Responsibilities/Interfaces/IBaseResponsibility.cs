namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

public interface IBaseResponsibility<in TInput>
{
    bool IsResponsible(TInput input);
}