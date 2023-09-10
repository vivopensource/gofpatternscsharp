using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

internal class Restaurant : CommandInvoker<IOrderCommand, IFoodCommandRequest>
{
    private readonly IConsoleLogger logger;

    public Restaurant(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void EatPizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);

        var serveOrder = new ServeOrderCommand();
        serveOrder.AddRequest(pizzas);

        AddCommand(serveOrder);
    }

    public void DeliverPizza(int count = 1)
    {
        var pizzas = new Pizza(logger, count);

        var deliverOrder = new DeliverOrderCommand();
        deliverOrder.AddRequest(pizzas);

        AddCommand(deliverOrder);
    }

    public void EatBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);

        var serveOrder = new ServeOrderCommand();
        serveOrder.AddRequest(burgers);

        AddCommand(serveOrder);
    }

    public void DeliverBurger(int count = 1)
    {
        var burgers = new Burger(logger, count);

        var deliverOrder = new DeliverOrderCommand();
        deliverOrder.AddRequest(burgers);

        AddCommand(deliverOrder);
    }
}