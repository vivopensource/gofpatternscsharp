using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofPattern.Behavioral.CommandPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;

internal interface IOrderCommand : ICommand<IFoodCommandRequest> { }