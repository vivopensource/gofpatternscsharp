namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities;

public interface IResponsibilityCheck<in TInput>
{
    bool IsResponsible(TInput input);
}