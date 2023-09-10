using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class CommandPatternExample : AbstractExample
{
    protected override bool Execute()
    {
        // ReSharper disable once JoinDeclarationAndInitializer

        int orderCount;
        var restaurant = new Restaurant(Logger);

        // 1st Order Batch
        restaurant.DeliverPizza(2);
        restaurant.DeliverBurger(5);
        restaurant.EatBurger(6);
        orderCount = restaurant.ExecuteCommands();
        Logger.Log($"Orders executed: {orderCount}");

        // 2nd Order Batch
        restaurant.EatBurger(3);
        restaurant.DeliverPizza(2);
        restaurant.EatPizza(3);
        restaurant.DeliverBurger(4);
        orderCount = restaurant.ExecuteCommands();
        Logger.Log($"Orders executed: {orderCount}");

        return true;
    }
}