using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;
using GofPatterns.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Commands;

internal class ServeFoodCommand : AbstractCommand<IFoodRequest>, IFoodCommand
{
    public override void Execute()
    {
        Request!.Serve();
    }
}