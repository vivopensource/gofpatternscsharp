using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;

internal class Pizza : AbstractFoodRequest
{
    internal Pizza(IConsoleLogger logger, int count = 1) : base(logger, nameof(Pizza), count) { }
}