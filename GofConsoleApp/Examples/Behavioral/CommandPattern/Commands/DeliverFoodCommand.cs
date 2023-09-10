using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;

internal class DeliverFoodCommand : AbstractCommand<IFoodCommandRequest>, IFoodCommand
{
    public override void Execute()
    {
        Request!.Pack();
    }
}