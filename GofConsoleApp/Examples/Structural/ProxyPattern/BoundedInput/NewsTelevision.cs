using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.BoundedInput;

internal class NewsTelevision : INewsTelevision
{
    private readonly IConsoleLogger logger;

    public NewsTelevision(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Process(EnumNewsChannel input)
    {
        logger.Log($"Broadcasting news from '{input}' channel");
    }
}