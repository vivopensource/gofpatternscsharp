using GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;
using GofPatterns.Behavioral.CommandPattern.Interfaces.Commands;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Commands;

internal interface IFoodCommand : ICommand<IFoodRequest> { }