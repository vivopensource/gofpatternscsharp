using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class CommandPatternRestaurantExample : BaseExample
{
    protected override bool Execute()
    {
        // ReSharper disable once JoinDeclarationAndInitializer

        int count;

        var restaurant = new RestaurantAsInvoker(Logger);

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