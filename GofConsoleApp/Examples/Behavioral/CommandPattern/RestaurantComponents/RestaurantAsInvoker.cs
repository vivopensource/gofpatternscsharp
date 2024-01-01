using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Commands;
using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;
using GofPatterns.Behavioral.CommandPattern;
using GofPatterns.Behavioral.CommandPattern.Interfaces.Invokers;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents;

/// <summary>
/// Invoker
/// </summary>
internal class RestaurantAsInvoker
{
    private readonly IConsoleLogger logger;
    private readonly ICommandInvoker<IFoodCommand, IFoodRequest> commandInvoker;

    public RestaurantAsInvoker(IConsoleLogger logger)
    {
        this.logger = logger;
        commandInvoker = new CommandInvoker<IFoodCommand, IFoodRequest>();
    }

    public void ServePizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);
        var serveOrder = new ServeFoodCommand();
        AddCommand(serveOrder, pizzas);
    }

    public void DeliverPizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);
        var deliverOrder = new DeliverFoodCommand();
        AddCommand(deliverOrder, pizzas);
    }

    public void ServeBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);
        var serveOrder = new ServeFoodCommand();
        AddCommand(serveOrder, burgers);
    }

    public void DeliverBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);
        var deliverOrder = new DeliverFoodCommand();
        AddCommand(deliverOrder, burgers);
    }

    private void AddCommand(IFoodCommand command, IFoodRequest request)
    {
        command.AddRequest(request);
        commandInvoker.AddCommand(command);
        
    }

    public int Prepare() => commandInvoker.ExecuteCommands();
}