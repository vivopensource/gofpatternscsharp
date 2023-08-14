using Core.Logging;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Burger : AbstractFoodCommandRequest
{
    internal Burger(ICustomLogger log, int count = 1) : base(log, nameof(Burger), count) { }
}