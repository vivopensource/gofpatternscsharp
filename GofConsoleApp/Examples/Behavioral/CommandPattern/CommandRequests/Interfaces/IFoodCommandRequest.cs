using GofPattern.Behavioral.CommandPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;

internal interface IFoodCommandRequest : ICommandRequest
{
    void Serve();

    void Pack();
}