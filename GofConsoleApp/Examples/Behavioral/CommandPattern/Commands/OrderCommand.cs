using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;

internal class OrderCommand : AbstractCommandUndo<Product>
{
    public OrderCommand(Product product)
    {
        AddRequest(product);
    }

    public override void Execute()
    {
        Request!.Purchase();
    }

    public override void UnExecute()
    {
        Request!.Return();
    }
}