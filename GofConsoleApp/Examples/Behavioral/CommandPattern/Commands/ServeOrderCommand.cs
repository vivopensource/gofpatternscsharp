using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;

internal class ServeOrderCommand : AbstractCommand<IFoodCommandRequest>, IOrderCommand
{
    public override void Handle()
    {
        Request!.Serve();
    }
}