using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Burger : AbstractFoodCommandRequest
{
    internal Burger(IConsoleLogger logger, int count = 1) : base(logger, nameof(Burger), count) { }
}