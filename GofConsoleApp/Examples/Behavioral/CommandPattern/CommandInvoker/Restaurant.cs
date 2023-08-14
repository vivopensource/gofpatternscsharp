using Core.Logging;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands;
using GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;
using GofPattern.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

internal class Restaurant : CommandInvoker<IOrderCommand, IFoodCommandRequest>
{
    private readonly ICustomLogger log;

    public Restaurant(ICustomLogger log)
    {
        this.log = log;
    }

    public void EatPizza(int count = 1)
    {
        var pizzas = new Pizza(log, count);

        var serveOrder = new ServeOrderCommand();
        serveOrder.AddRequest(pizzas);

        AddCommand(serveOrder);
    }

    public void DeliverPizza(int count = 1)
    {
        var pizzas = new Pizza(log, count);

        var deliverOrder = new DeliverOrderCommand();
        deliverOrder.AddRequest(pizzas);

        AddCommand(deliverOrder);
    }

    public void EatBurger(int count = 1)
    {
        var burgers = new Burger(log, count);

        var serveOrder = new ServeOrderCommand();
        serveOrder.AddRequest(burgers);

        AddCommand(serveOrder);
    }

    public void DeliverBurger(int count = 1)
    {
        var burgers = new Burger(log, count);

        var deliverOrder = new DeliverOrderCommand();
        deliverOrder.AddRequest(burgers);

        AddCommand(deliverOrder);
    }
}