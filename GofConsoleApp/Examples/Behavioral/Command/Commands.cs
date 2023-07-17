using GofPattern.Behavioral.Command;
using GofPattern.Behavioral.Command.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.Command;


internal interface IOrderCommand : ICommand<IFoodCommandRequest> { }



internal class ServeOrderCommand : AbstractCommand<IFoodCommandRequest>, IOrderCommand
{
    public override void Execute() => Req!.Serve();
}



internal class DeliverOrderCommand : AbstractCommand<IFoodCommandRequest>, IOrderCommand
{
    public override void Execute() => Req!.Pack();
}