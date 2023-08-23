using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Pizza : AbstractFoodCommandRequest
{
    internal Pizza(IConsoleLogger logger, int count = 1) : base(logger, nameof(Pizza), count) { }
}