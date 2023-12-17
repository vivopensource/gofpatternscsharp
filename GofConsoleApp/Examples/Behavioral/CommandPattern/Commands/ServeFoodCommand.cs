using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;
using GofPatterns.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;

internal class ServeFoodCommand : AbstractCommand<IFoodCommandRequest>, IFoodCommand
{
    public override void Execute()
    {
        Request!.Serve();
    }
}