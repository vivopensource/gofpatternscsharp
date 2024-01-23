using GofPatterns.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;

internal interface IFoodRequest : ICommandRequest
{
    void Serve();

    void Pack();
}