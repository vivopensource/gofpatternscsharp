using Core.Logging;
using GofPattern.Behavioral.Command;

namespace GofConsoleApp.Examples.Behavioral.Command;

internal class CommandInvokerExample
{
    private readonly ICustomLogger log;
    private readonly CommandInvoker<IOrderCommand, IFoodCommandRequest> invoker;

    public CommandInvokerExample(ICustomLogger log)
    {
        this.log = log;
        invoker = new();
    }

    public void EatPizza(int count = 1)
    {
        var pizzas = new Pizza(log, count);

        var serveOrder = new ServeOrderCommand();
        serveOrder.AddRequest(pizzas);

        invoker.AddCommand(serveOrder);
    }

    public void DeliverPizza(int count = 1)
    {
        var pizzas = new Pizza(log, count);

        var deliverOrder = new DeliverOrderCommand();
        deliverOrder.AddRequest(pizzas);

        invoker.AddCommand(deliverOrder);
    }

    public void EatBurger(int count = 1)
    {
        var burgers = new Burger(log, count);

        var serveOrder = new ServeOrderCommand();
        serveOrder.AddRequest(burgers);

        invoker.AddCommand(serveOrder);
    }

    public void DeliverBurger(int count = 1)
    {
        var burgers = new Burger(log, count);

        var deliverOrder = new DeliverOrderCommand();
        deliverOrder.AddRequest(burgers);

        invoker.AddCommand(deliverOrder);
    }

    public void InvokeOrder() => invoker.ExecuteCommand();
}