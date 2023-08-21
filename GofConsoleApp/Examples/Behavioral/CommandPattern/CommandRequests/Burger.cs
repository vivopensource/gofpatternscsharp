using Core.Console;
using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Burger : AbstractFoodCommandRequest
{
    internal Burger(IConsoleLogger log, int count = 1) : base(log, nameof(Burger), count) { }
}