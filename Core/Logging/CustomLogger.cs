using Microsoft.Extensions.Logging;

namespace Core.Logging;

internal class CustomLogger : ICustomLogger
{
    private readonly ILogger logger;

    internal CustomLogger(ILogger logger)
    {
        this.logger = logger;
    }

    public virtual void LogInformation(string message)
    {
        logger.LogInformation(message);
    }
}

internal interface ICustomLogger
{
    void LogInformation(string message);
}