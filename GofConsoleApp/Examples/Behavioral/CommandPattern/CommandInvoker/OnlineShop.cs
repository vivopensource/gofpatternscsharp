using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

internal class OnlineShop : CommandUndoInvoker<TransactionCommand, ProductRequest>
{
    private readonly IConsoleLogger logger;

    public OnlineShop(IConsoleLogger logger) => this.logger = logger;

    public void PurchaseProduct(string productName)
    {
        var productRequest = new ProductRequest(logger, productName); // Request
        var transactionCommand = new TransactionCommand(productRequest); // Command
        AddCommand(transactionCommand, false);
    }

    public void ReturnProduct(string productName)
    {
        var productRequest = new ProductRequest(logger, productName); // Request
        var transactionCommand = new TransactionCommand(productRequest); // Command
        AddCommand(transactionCommand, true);
    }
}