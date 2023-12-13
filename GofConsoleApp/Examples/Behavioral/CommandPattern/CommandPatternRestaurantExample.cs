using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class CommandPatternRestaurantExample : AbstractExample
{
    protected override bool Execute()
    {
        // ReSharper disable once JoinDeclarationAndInitializer

        int count;

        var restaurant = new Restaurant(Logger);

        // 1st Order Batch
        restaurant.DeliverPizza(2);
        restaurant.DeliverBurger(5);
        restaurant.ServeBurger(6);
        count = restaurant.Prepare();
        Logger.Log($"Orders executed: {count}");

        // 2nd Order Batch
        restaurant.ServeBurger(3);
        restaurant.DeliverPizza(2);
        restaurant.ServePizza(3);
        restaurant.DeliverBurger(4);
        count = restaurant.Prepare();
        Logger.Log($"Orders executed: {count}");

        return true;
    }
}