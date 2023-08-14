using Core.Logging;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Pizza : AbstractFoodCommandRequest
{
    internal Pizza(ICustomLogger log, int count = 1) : base(log, nameof(Pizza), count) { }
}