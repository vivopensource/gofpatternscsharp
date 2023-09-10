using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;

internal class TransactionCommand : AbstractCommandUndo<Product>
{
    public TransactionCommand(Product product)
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