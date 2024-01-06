using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Commands;
using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;
using GofPatterns.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents;

/// <summary>
/// Invoker
/// </summary>
internal class RestaurantAsInvoker : CommandInvoker<IFoodCommand, IFoodRequest>
{
    private readonly IConsoleLogger logger;

    public RestaurantAsInvoker(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void ServePizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);
        var serveOrder = new ServeFoodCommand();
        serveOrder.AddRequest(pizzas);
        AddCommand(serveOrder);
    }

    public void DeliverPizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);
        var deliverOrder = new DeliverFoodCommand();
        deliverOrder.AddRequest(pizzas);
        AddCommand(deliverOrder);
    }

    public void ServeBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);
        var serveOrder = new ServeFoodCommand();
        serveOrder.AddRequest(burgers);
        AddCommand(serveOrder);
    }

    public void DeliverBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);
        var deliverOrder = new DeliverFoodCommand();
        deliverOrder.AddRequest(burgers);
        AddCommand(deliverOrder);
    }

    public int Prepare() => ExecuteCommands();
}