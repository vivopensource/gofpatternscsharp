namespace GofPatterns.Behavioral.MediatorPattern;

public interface IMediator<in TColleagueIdentifier, in TInput>
{
    void Send(TColleagueIdentifier identifier, TInput input);
}