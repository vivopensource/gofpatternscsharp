using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;

internal class TransactionCommand : AbstractCommandUndo<ProductRequest>
{
    public TransactionCommand(ProductRequest productRequest)
    {
        AddRequest(productRequest);
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