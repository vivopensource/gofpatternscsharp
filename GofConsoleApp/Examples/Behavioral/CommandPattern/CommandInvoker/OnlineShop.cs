using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;
using GofPatterns.Behavioral.CommandPattern;
using GofPatterns.Behavioral.CommandPattern.Interfaces.Invokers;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

internal class OnlineShop
{
    private readonly IConsoleLogger logger;
    private readonly ICommandUndoInvoker<TransactionCommand, ProductRequest> commandUndoInvoker;

    public OnlineShop(IConsoleLogger logger)
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