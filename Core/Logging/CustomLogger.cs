using Microsoft.Extensions.Logging;

namespace Core.Logging;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
internal class CustomLogger : ICustomLogger
{
    private readonly ILogger logger;

    internal CustomLogger(ILogger logger)
    {
        this.logger = logger;
    }

    public virtual void LogInformation(string info)
    {
        logger.LogInformation("Message: {Info}",info);
    }
}

internal interface ICustomLogger
{
    void LogInformation(string info);
}