namespace GofPatterns.Behavioral.MediatorPattern.Interfaces;

public interface ICommunicator<in TColleagueIdentifier, in TInput>
{
    void Send(TColleagueIdentifier identifier, TInput input);
}