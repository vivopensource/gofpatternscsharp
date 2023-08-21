using Core.Console;
using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Pizza : AbstractFoodCommandRequest
{
    internal Pizza(IConsoleLogger log, int count = 1) : base(log, nameof(Pizza), count) { }
}