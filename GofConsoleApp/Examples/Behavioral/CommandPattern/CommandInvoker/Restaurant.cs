using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;
using GofPattern.Behavioral.CommandPattern;
using GofPattern.Behavioral.CommandPattern.Interfaces.Invokers;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

internal class Restaurant
{
    private readonly IConsoleLogger logger;
    private readonly ICommandInvoker<IFoodCommand, IFoodCommandRequest> commandInvoker;

    public Restaurant(IConsoleLogger logger)
    {
        this.logger = logger;
        commandInvoker = new CommandInvoker<IFoodCommand, IFoodCommandRequest>();
    }

    public void ServePizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);

        var serveOrder = new ServeFoodCommand();
        serveOrder.AddRequest(pizzas);

        commandInvoker.AddCommand(serveOrder);
    }

    public void DeliverPizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);

        var deliverOrder = new DeliverFoodCommand();
        deliverOrder.AddRequest(pizzas);

        commandInvoker.AddCommand(deliverOrder);
    }

    public void ServeBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);

        var serveOrder = new ServeFoodCommand();
        serveOrder.AddRequest(burgers);

        commandInvoker.AddCommand(serveOrder);
    }

    public void DeliverBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);

        var deliverOrder = new DeliverFoodCommand();
        deliverOrder.AddRequest(burgers);

        commandInvoker.AddCommand(deliverOrder);
    }

    public int Prepare() => commandInvoker.ExecuteCommands();
}