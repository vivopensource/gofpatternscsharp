using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;

internal class Burger : AbstractFoodRequest
{
    internal Burger(IConsoleLogger logger, int count = 1) : base(logger, nameof(Burger), count) { }
}