using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.NewsChannel;

internal class NewsChannel : INewsChannel
{
    private readonly IConsoleLogger logger;

    public NewsChannel(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Process(EnumNewsChannel input)
    {
        logger.Log($"Broadcasting news from '{input}' channel");
    }
}