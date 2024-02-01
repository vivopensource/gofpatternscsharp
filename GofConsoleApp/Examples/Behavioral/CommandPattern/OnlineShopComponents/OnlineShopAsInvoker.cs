using Core.Console.Interfaces;
using GofPatterns.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.OnlineShopComponents;

internal class OnlineShopAsInvoker
{
    private readonly IConsoleLogger logger;
    private readonly ICommandInvokerUndo<TransactionCommand, ProductRequest> commandInvokerUndo;

    public OnlineShopAsInvoker(IConsoleLogger logger)
    {
        this.logger = logger;
        commandInvokerUndo = new CommandInvokerUndo<TransactionCommand, ProductRequest>();
    }

    public void PurchaseProduct(string productName)
    {
        var productRequest = new ProductRequest(logger, productName); // Request
        var transactionCommand = new TransactionCommand(productRequest); // Command
        commandInvokerUndo.AddCommand(transactionCommand, false);
    }

    public void ReturnProduct(string productName)
    {
        var productRequest = new ProductRequest(logger, productName); // Request
        var transactionCommand = new TransactionCommand(productRequest); // Command
        commandInvokerUndo.AddCommand(transactionCommand, true);
    }

    public int CheckOut() => commandInvokerUndo.ExecuteCommands();
}