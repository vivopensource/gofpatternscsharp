using Core.Console.Interfaces;
using GofPatterns.Behavioral.CommandPattern;
using GofPatterns.Behavioral.CommandPattern.Interfaces.Invokers;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.OnlineShopComponents;

internal class OnlineShopAsInvoker
{
    private readonly IConsoleLogger logger;
    private readonly ICommandUndoInvoker<TransactionCommand, ProductRequest> commandUndoInvoker;

    public OnlineShopAsInvoker(IConsoleLogger logger)
    {
        this.logger = logger;
        commandUndoInvoker = new CommandUndoInvoker<TransactionCommand, ProductRequest>();
    }

    public void PurchaseProduct(string productName)
    {
        var productRequest = new ProductRequest(logger, productName); // Request
        var transactionCommand = new TransactionCommand(productRequest); // Command
        commandUndoInvoker.AddCommand(transactionCommand, false);
    }

    public void ReturnProduct(string productName)
    {
        var productRequest = new ProductRequest(logger, productName); // Request
        var transactionCommand = new TransactionCommand(productRequest); // Command
        commandUndoInvoker.AddCommand(transactionCommand, true);
    }

    public int CheckOut() => commandUndoInvoker.ExecuteCommands();
}