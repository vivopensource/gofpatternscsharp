using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern;

internal class Example : AbstractExample
{
    protected override void Steps()
    {
        var restaurant = new Restaurant(Logger);

        // Order >> 1
        restaurant.DeliverPizza(2);
        restaurant.DeliverBurger(5);
        restaurant.EatBurger(6);
        restaurant.HandleCommands();

        // Order >> 2
        restaurant.EatBurger(3);
        restaurant.EatPizza(3);
        restaurant.HandleCommands();
    }
}